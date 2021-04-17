using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Comparateur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Comparateur : ControllerBase
    {

        [Route("/Trivago/Comparateur")]
        [HttpGet]
        public string Get(string ville, string dateDebut, string dateFin, int nombrePersonne, int nombreEtoile)
        {
            String url = "https://localhost:44350/";
            string offresHotelPasCher = GetReleases(url + "HotelPasCher/getOffreComparateur?ville=" + ville + "&dateDebut=" + dateDebut + "&dateFin=" + dateFin + "&nombrePersonne=" + nombrePersonne + "&nombreEtoile=" + nombreEtoile);
            string offreHotelPlusCher = GetReleases(url + "HotelPlusCher/getOffreComparateur?ville=" + ville + "&dateDebut=" + dateDebut + "&dateFin=" + dateFin + "&nombrePersonne=" + nombrePersonne + "&nombreEtoile=" + nombreEtoile);
            return offresHotelPasCher + offreHotelPlusCher;

         
        }

        [Route("/Trivago/GetReleases")]
        [HttpGet]
        public String GetReleases(String url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }

            String resultat = content.ToString();
            return resultat.Replace("\"", "");
        }
    }
}
