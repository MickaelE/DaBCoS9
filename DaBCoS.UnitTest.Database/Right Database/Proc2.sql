if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Proc1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Proc1]
GO


CREATE PROCEDURE dbo.Proc1 AS

SELECT
	1
