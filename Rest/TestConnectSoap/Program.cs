// See https://aka.ms/new-console-template for more information
using System.ServiceModel;

var serviceUrl = "https://localhost:44389/WebService.asmx";

var endpointAddress = new EndpointAddress(serviceUrl);

var basicHttpBinding = new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport);
basicHttpBinding.OpenTimeout = TimeSpan.MaxValue;
basicHttpBinding.CloseTimeout = TimeSpan.MaxValue;
basicHttpBinding.ReceiveTimeout = TimeSpan.MaxValue;
basicHttpBinding.SendTimeout = TimeSpan.MaxValue;
var SoapWebService = new SoapWebService.WebServiceSoapClient(basicHttpBinding, endpointAddress);
var result = await SoapWebService.HelloWorldAsync();

Console.WriteLine("Soap Demo: " + result.Body.HelloWorldResult);
