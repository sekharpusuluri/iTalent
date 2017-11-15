#r "System.Configuration"
#r "System.Data"
#r "System.Net"
#r "Newtonsoft.Json"
#r "iTalent.LithiumConnector.dll"

using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using iTalent.LithiumConnector;
using System.Configuration;

public static void Run(TimerInfo myTimer, TraceWriter log)
{
    log.Info($"Starting the GetLithiumData function execution at: {DateTime.Now.ToString()}");

    string strTenantID = ConfigurationManager.AppSettings["TenentID"].ToString();
    string strClientID = ConfigurationManager.AppSettings["ClientID"].ToString();
    string strClientSecret = ConfigurationManager.AppSettings["ClientSecret"].ToString();
    string strRefreshToken = ConfigurationManager.AppSettings["RefreshToken"].ToString();

    string strSQLConn = ConfigurationManager.ConnectionStrings["AzureSQLConn"].ToString();

    GetPBIData getPBIData = new GetPBIData(log);
    getPBIData.LoadandProcessLithiumData(strSQLConn, strTenantID, strClientID, strClientSecret, strRefreshToken);

    log.Info($"Completed the GetLithiumData function execution at: {DateTime.Now} .");
}
