<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:ci="customedifact">
    <xsl:output method="xml" indent="yes"/>

  <xsl:template match="ci:CustomInvoic">
    <xsl:element name="ns0:M_INVOIC" namespace="www.edifabric.com/edifact">
      <xsl:copy-of select="@*"/>
      <xsl:apply-templates/>
    </xsl:element>
  </xsl:template>

  <xsl:template match="*">
    <xsl:element name="ns0:{name()}" namespace="www.edifabric.com/edifact">
      <xsl:copy-of select="@*"/>
      <xsl:apply-templates/>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>

