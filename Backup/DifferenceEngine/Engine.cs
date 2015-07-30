using System;
using System.Collections;

namespace DifferenceEngine
{
	public enum DiffEngineLevel
	{
		FastImperfect,
		Medium,
		SlowPerfect
	}

	public class DiffEngine
	{
		private IDiffList _source;
		private IDiffList _dest;
		private ArrayList _matchList;

		private DiffEngineLevel _level;

		private DiffStateList _stateList;

		public DiffEngine() 
		{
			_source = null;
			_dest = null;
			_matchList = null;
			_stateList = null;
			_level = DiffEngineLevel.FastImperfect;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destIndex"></param>
		/// <param name="sourceIndex"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		private int GetSourceMatchLength(int destIndex, int sourceIndex, int maxLength)
		{
			int matchCount;
			for (matchCount = 0; matchCount < maxLength; matchCount++)
			{
				if ( _dest.GetByIndex(destIndex + matchCount).CompareTo(_source.GetByIndex(sourceIndex + matchCount)) != 0 )
				{
					break;
				}
			}
			return matchCount;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="curItem"></param>
		/// <param name="destIndex"></param>
		/// <param name="destEnd"></param>
		/// <param name="sourceStart"></param>
		/// <param name="sourceEnd"></param>
		private void GetLongestSourceMatch(DiffState curItem, int destIndex,int destEnd, int sourceStart,int sourceEnd)
		{
			
			int maxDestLength = (destEnd - destIndex) + 1;
			int curLength = 0;
			int curBestLength = 0;
			int curBestIndex = -1;
			int maxLength = 0;
			for (int sourceIndex = sourceStart; sourceIndex <= sourceEnd; sourceIndex++)
			{
				maxLength = Math.Min(maxDestLength,(sourceEnd - sourceIndex) + 1);
				if (maxLength <= curBestLength)
				{
					//No chance to find a longer one any more
					break;
				}
				curLength = GetSourceMatchLength(destIndex,sourceIndex,maxLength);
				if (curLength > curBestLength)
				{
					//This is the best match so far
					curBestIndex = sourceIndex;
					curBestLength = curLength;
				}
				//jump over the match
				sourceIndex += curBestLength; 
			}
			//DiffState cur = _stateList.GetByIndex(destIndex);
			if (curBestIndex == -1)
			{
				curItem.SetNoMatch();
			}
			else
			{
				curItem.SetMatch(curBestIndex, curBestLength);
			}
		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="destStart"></param>
		/// <param name="destEnd"></param>
		/// <param name="sourceStart"></param>
		/// <param name="sourceEnd"></param>
		private void ProcessRange(int destStart, int destEnd, int sourceStart, int sourceEnd)
		{
			int curBestIndex = -1;
			int curBestLength = -1;
			int maxPossibleDestLength = 0;
			DiffState currentDiffState = null;
			DiffState bestDiffState = null;
			for (int destIndex = destStart; destIndex <= destEnd; destIndex++)
			{
				maxPossibleDestLength = (destEnd - destIndex) + 1;
				if (maxPossibleDestLength <= curBestLength)
				{
					//we won't find a longer one even if we looked
					break;
				}
				currentDiffState = _stateList.GetByIndex(destIndex);
				
				if (!currentDiffState.HasValidLength(sourceStart, sourceEnd, maxPossibleDestLength))
				{
					//recalc new best length since it isn't valid or has never been done.
					GetLongestSourceMatch(currentDiffState, destIndex, destEnd, sourceStart, sourceEnd);
				}
				if (currentDiffState.Status == DiffStatus.Matched)
				{
					switch (_level)
					{
						case DiffEngineLevel.FastImperfect:
							if (currentDiffState.Length > curBestLength)
							{
								//this is longest match so far
								curBestIndex = destIndex;
								curBestLength = currentDiffState.Length;
								bestDiffState = currentDiffState;
							}
							//Jump over the match 
							destIndex += currentDiffState.Length - 1; 
							break;
						case DiffEngineLevel.Medium: 
							if (currentDiffState.Length > curBestLength)
							{
								//this is longest match so far
								curBestIndex = destIndex;
								curBestLength = currentDiffState.Length;
								bestDiffState = currentDiffState;
								//Jump over the match 
								destIndex += currentDiffState.Length - 1; 
							}
							break;
						default:
							if (currentDiffState.Length > curBestLength)
							{
								//this is longest match so far
								curBestIndex = destIndex;
								curBestLength = currentDiffState.Length;
								bestDiffState = currentDiffState;
							}
							break;
					}
				}
			}
			if (curBestIndex < 0)
			{
				//we are done - there are no matches in this span
			}
			else
			{
	
				int sourceIndex = bestDiffState.StartIndex;
				_matchList.Add(DiffResultSpan.CreateNoChange(curBestIndex,sourceIndex,curBestLength));
				if (destStart < curBestIndex)
				{
					//Still have more lower destination data
					if (sourceStart < sourceIndex)
					{
						//Still have more lower source data
						// Recursive call to process lower indexes
						ProcessRange(destStart, curBestIndex -1,sourceStart, sourceIndex -1);
					}
				}
				int upperDestStart = curBestIndex + curBestLength;
				int upperSourceStart = sourceIndex + curBestLength;
				if (destEnd > upperDestStart)
				{
					//we still have more upper dest data
					if (sourceEnd > upperSourceStart)
					{
						//set still have more upper source data
						// Recursive call to process upper indexes
						ProcessRange(upperDestStart,destEnd,upperSourceStart,sourceEnd);
					}
				}
			}
		}

		public double ProcessDiff(IDiffList source, IDiffList destination,DiffEngineLevel level)
		{
			_level = level;
			return ProcessDiff(source,destination);
		}

		public double ProcessDiff(IDiffList source, IDiffList destination)
		{
			DateTime dt = DateTime.Now;
			_source = source;
			_dest = destination;
			_matchList = new ArrayList();
			
			int dcount = _dest.Count();
			int scount = _source.Count();
			
			
			if ((dcount > 0)&&(scount > 0))
			{
				_stateList = new DiffStateList(dcount);
				ProcessRange(0,dcount - 1,0, scount - 1);
			}

			TimeSpan ts = DateTime.Now - dt;
			return ts.TotalSeconds;
		}


		private bool AddChanges(
			DiffResultSpanCollection report, 
			int curDest,
			int nextDest,
			int curSource,
			int nextSource)
		{
			bool returnResultSpanCollection = false;
			int diffDest = nextDest - curDest;
			int diffSource = nextSource - curSource;
			int minDiff = 0;
			if (diffDest > 0)
			{
				if (diffSource > 0)
				{
					minDiff = Math.Min(diffDest,diffSource);
					report.Add(DiffResultSpan.CreateReplace(curDest,curSource,minDiff));
					if (diffDest > diffSource)
					{
						curDest+=minDiff;
						report.Add(DiffResultSpan.CreateAddDestination(curDest,diffDest - diffSource)); 
					}
					else
					{
						if (diffSource > diffDest)
						{
							curSource+= minDiff;
							report.Add(DiffResultSpan.CreateDeleteSource(curSource,diffSource - diffDest));
						}
					}	
				}
				else
				{
					report.Add(DiffResultSpan.CreateAddDestination(curDest,diffDest)); 
				}
				returnResultSpanCollection = true;
			}
			else
			{
				if (diffSource > 0)
				{
					report.Add(DiffResultSpan.CreateDeleteSource(curSource,diffSource));  
					returnResultSpanCollection = true;
				}
			}
			return returnResultSpanCollection;
		}

		public DiffResultSpanCollection DiffReport()
		{
			DiffResultSpanCollection returnResultSpanCollection = new DiffResultSpanCollection();
			int dcount = _dest.Count();
			int scount = _source.Count();
			
			//Deal with the special case of empty files
			if (dcount == 0)
			{
				if (scount > 0)
				{
					returnResultSpanCollection.Add(DiffResultSpan.CreateDeleteSource(0,scount));
				}
				return returnResultSpanCollection;
			}
			else
			{
				if (scount == 0)
				{
					returnResultSpanCollection.Add(DiffResultSpan.CreateAddDestination(0,dcount));
					return returnResultSpanCollection;
				}
			}


			_matchList.Sort();
			int curDest = 0;
			int curSource = 0;
			DiffResultSpan lastResultSpan = null;

			//Process each match record
			foreach (DiffResultSpan resultSpan in _matchList)
			{
				if ((!AddChanges(returnResultSpanCollection,curDest,resultSpan.DestIndex,curSource,resultSpan.SourceIndex))&&
					(lastResultSpan != null))
				{
					lastResultSpan.AddLength(resultSpan.Length);
				}
				else
				{
					returnResultSpanCollection.Add(resultSpan);
				}
				curDest = resultSpan.DestIndex + resultSpan.Length;
				curSource = resultSpan.SourceIndex + resultSpan.Length;
				lastResultSpan = resultSpan;
			}
			
			//Process any tail end data
			AddChanges(returnResultSpanCollection,curDest,dcount,curSource,scount);

			return returnResultSpanCollection;
		}
	}
}
