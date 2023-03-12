using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Countries.States.Cities.Net6.Rest.Api.Model;

namespace Countries.States.Cities.Net6.Rest.Api.Controllers
{
    [ApiController]
    public class GetLocationController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;

        public GetLocationController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        [Route("GetCountries/All")]
        public Response<Model.Countries> GetAllCountries()
        {
            string jsonPath = _hostingEnvironment.ContentRootPath + "\\JSON\\countries.json";

            var GetAllCountries = ReadAll<Model.Countries>(jsonPath);

            if (GetAllCountries != null)
            {
                return new Success<Model.Countries>(GetAllCountries, "İşlem Başarılı", GetAllCountries.Count + " Ülke Bulundu");
            }
            else
            {
                return new Failure<Model.Countries>("Veriye Ulaşılamadı.");
            }
        }

        [Route("GetCountries/{CountriesId}")]
        public Response<Model.Countries> GetCountriesByID(int CountriesId)
        {
            string jsonPath = _hostingEnvironment.ContentRootPath + "\\JSON\\countries.json";

            var GetCountries = Read<Model.Countries>(jsonPath, x => x.id == CountriesId);

            if (CountriesId == 0)
            {
                return new Failure<Model.Countries>("Veriye Ulaşılamadı.", "Lütfen Ülke idsini giriniz.");
            }
            else
            {
                if (GetCountries != null)
                {
                    return new Success<Model.Countries>(GetCountries, "İşlem Başarılı", "");
                }
                else
                {
                    return new Failure<Model.Countries>("Veriye Ulaşılamadı.");
                }
            }
        }

        [Route("GetStates/{CountriesId}")]
        public Response<Model.States> GetStatesByID(int CountriesId)
        {
            string jsonPath = _hostingEnvironment.ContentRootPath + "\\JSON\\states.json";

            var GetStates = Read<Model.States>(jsonPath, x => x.country_id == CountriesId);

            if (CountriesId == 0)
            {
                return new Failure<Model.States>("Veriye Ulaşılamadı.", "Lütfen Ülke idsini giriniz.");
            }
            else if (GetStates != null)
            {
                return new Success<Model.States>(GetStates, "İşlem Başarılı", GetStates.Count() + " il Bulundu");
            }
            else
            {
                return new Failure<Model.States>("Veriye Ulaşılamadı.");
            }


        }

        [Route("GetCities/{StatesId}")]
        public Response<Model.Cities> GetCitiesByID(int StatesID)
        {
            string jsonPath = _hostingEnvironment.ContentRootPath + "\\JSON\\cities.json";

            var GetCities = Read<Model.Cities>(jsonPath, x => x.state_id == StatesID);

            if (GetCities != null)
            {
                return new Success<Model.Cities>(GetCities, "İşlem Başarılı", GetCities.Count() + " ilçe Bulundu");
            }
            else
            {
                return new Failure<Model.Cities>("Veriye Ulaşılamadı.");
            }

        }

        private List<T> ReadAll<T>(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                var data = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd());

                return data;
            }

        }

        private List<T> Read<T>(string path, Func<T, bool> f)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                var data = JsonConvert.DeserializeObject<List<T>>(sr.ReadToEnd()).Where(f).ToList();

                return data;
            }

        }
    }
}
