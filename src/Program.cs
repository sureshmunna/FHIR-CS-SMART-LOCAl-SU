using System;
using Hl7.Fhir.Rest;


namespace smart_local
{
    /// <summary>
    /// main Program
    /// </summary>
    public static class program
    {
        private const string _defaultFhirServerUrl = "https://launch.smarthealthit.org/v/r4/sim/WzIsIiIsIjYzMDAzYWJiLTM5MjQtNDZkZi1hNzVhLTBhMWY0MjczMzE4OSIsIkFVVE8iLDAsMCwwLCIiLCIiLCIiLCIiLCIiLCIiLCIiLDAsMSwiIl0/fhir/";
        /// <summary>
        /// program to access a SMART FHIR Server with a local webserver for redirection 
        /// </summary>
        /// <param name="fhirServerUrl">FHIR R4 endpoint URL </param>
        static int Main(String  fhirServerUrl)
        {
            if (string.IsNullOrEmpty(fhirServerUrl))
            {
                fhirServerUrl = _defaultFhirServerUrl;
            }

            System.Console.WriteLine($"  FHIR Server : {fhirServerUrl}");

            Hl7.Fhir.Rest.FhirClient fhirClient = new Hl7.Fhir.Rest.FhirClient(fhirServerUrl);

            if(!FhitUtils.TryGetSmartUrls(fhirClient ,out string authorizeUrl , out string tokenUrl)){
                System.Console.WriteLine("Failed to discover SMART URLs");
                return -1;
            }

            System.Console.WriteLine($"Authorize URL : {authorizeUrl}");
            System.Console.WriteLine($"    Token URL : {tokenUrl}");

            return 0;
        }
    }
}