using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaBCoS.Engine
{
   public class CreateSync
    {
        public static String addTableRowDDL(String Table, String source) {
            String RetVal;
            String AlterStatement = "Alter table " + Table;
            String AddStatement = " ADD " + source;
            RetVal = AlterStatement + AddStatement + ";";
            return RetVal;
        }
        public static String addViewRowDDL(String View, String source)
        {
            String RetVal;
            String AlterStatement = "Alter View " + View;
            String AddStatement = " ADD " + source;
            RetVal = AlterStatement + AddStatement + ";";
            return RetVal;
        }
        public static String CreateSpDdl(String source)
        {
            String RetVal = "";
            return RetVal;
        }
    }
}
