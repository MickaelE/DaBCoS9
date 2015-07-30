<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<xsl:apply-templates select="//*[@outcome!='Same']"/>
	</xsl:template>
	<xsl:template match="table">
		Table `
		<xsl:value-of select="@name"/>
		` is
		<xsl:value-of select="@outcome"/>
		<BR/>
	</xsl:template>
	<xsl:template match="function">
		Table `
		<xsl:value-of select="@name"/>
		` is
		<xsl:value-of select="@outcome"/>
		<BR/>
	</xsl:template>
	<xsl:template match="storedprocedure">
		Table `
		<xsl:value-of select="@name"/>
		` is
		<xsl:value-of select="@outcome"/>
		<BR/>
	</xsl:template>
	<xsl:template match="view">
		Table `
		<xsl:value-of select="@name"/>
		` is
		<xsl:value-of select="@outcome"/>
		<BR/>
	</xsl:template>
</xsl:stylesheet>
