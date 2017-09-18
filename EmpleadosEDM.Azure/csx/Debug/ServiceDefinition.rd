<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="EmpleadosEDM.Azure" generation="1" functional="0" release="0" Id="8de6f65d-e6ed-431f-8965-f7e6a68c85f5" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="EmpleadosEDM.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="EmpleadosEDM:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/LB:EmpleadosEDM:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="EmpleadosEDM:APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="">
          <maps>
            <mapMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/MapEmpleadosEDM:APPINSIGHTS_INSTRUMENTATIONKEY" />
          </maps>
        </aCS>
        <aCS name="EmpleadosEDM:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/MapEmpleadosEDM:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="EmpleadosEDMInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/MapEmpleadosEDMInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:EmpleadosEDM:Endpoint1">
          <toPorts>
            <inPortMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/EmpleadosEDM/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapEmpleadosEDM:APPINSIGHTS_INSTRUMENTATIONKEY" kind="Identity">
          <setting>
            <aCSMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/EmpleadosEDM/APPINSIGHTS_INSTRUMENTATIONKEY" />
          </setting>
        </map>
        <map name="MapEmpleadosEDM:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/EmpleadosEDM/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapEmpleadosEDMInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/EmpleadosEDMInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="EmpleadosEDM" generation="1" functional="0" release="0" software="C:\Users\PABLO\Desktop\EmpleadosEDM\EmpleadosEDM.Azure\csx\Debug\roles\EmpleadosEDM" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;EmpleadosEDM&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;EmpleadosEDM&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/EmpleadosEDMInstances" />
            <sCSPolicyUpdateDomainMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/EmpleadosEDMUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/EmpleadosEDMFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="EmpleadosEDMUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="EmpleadosEDMFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="EmpleadosEDMInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="e82cdf7b-8b46-4b4e-8ec5-55a7056b44fd" ref="Microsoft.RedDog.Contract\ServiceContract\EmpleadosEDM.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="f45e7ea7-aac0-49bb-afb7-419acbc52131" ref="Microsoft.RedDog.Contract\Interface\EmpleadosEDM:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/EmpleadosEDM.Azure/EmpleadosEDM.AzureGroup/EmpleadosEDM:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>