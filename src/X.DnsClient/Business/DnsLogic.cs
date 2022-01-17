using DnsClient;
using X.DnsClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace X.DnsClient.Business
{
    public class DnsLogic
    {
        public List<AResult> ARecordResult(string hostname, string apiKey)
        {
            var lookup = new LookupClient();

            List<AResult> results = new List<AResult>();
            foreach (var aRecord in lookup.Query(hostname, QueryType.A).Answers.ARecords())
            {
                AResult result = new AResult
                {
                    Domain = hostname,
                    PointsTo = aRecord.Address.ToString(),
                    Ttl = aRecord.InitialTimeToLive.ToString(),
                    Type = aRecord.RecordType.ToString()
                };

                results.Add(result);
            }

            return results;
        }

        public List<MXResult> MXRecordResult(string hostname, string apiKey)
        {
            var lookup = new LookupClient();

            List<MXResult> results = new List<MXResult>();
            foreach (var mxRecord in lookup.Query(hostname, QueryType.MX).Answers.MxRecords())
            {
                MXResult result = new MXResult
                {
                    Domain = hostname,
                    Type = mxRecord.RecordType.ToString(),
                    Host = mxRecord.DomainName.Value,
                    PointsTo = mxRecord.Exchange.ToString(),
                    Priority = mxRecord.Preference.ToString(),
                    Ttl = mxRecord.InitialTimeToLive.ToString(),
                };

                results.Add(result);
            }

            return results;
        }

        public List<TXTResult> TXTRecordResult(string hostname, string apiKey)
        {
            var lookup = new LookupClient();

            List<TXTResult> results = new List<TXTResult>();
            foreach (var txtRecord in lookup.Query(hostname, QueryType.TXT).Answers.TxtRecords())
            {
                TXTResult result = new TXTResult();
                foreach(string txtText in txtRecord.Text)
                {
                    result.Domain = hostname;
                    result.Type = txtRecord.RecordType.ToString();
                    result.Host = txtRecord.DomainName.Value;
                    result.Ttl = txtRecord.InitialTimeToLive.ToString();
                    result.PointsTo = txtText.ToString();

                    results.Add(result);
                }
            }

            return results;
        }
    }
}
