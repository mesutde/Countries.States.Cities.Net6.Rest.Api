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
        public Response<Countries.States.Cities.Net6.Rest.Api.Model.Countries> GetAllCountries()
        {
            Response<Countries.States.Cities.Net6.Rest.Api.Model.Countries> retVal = new Response<Countries.States.Cities.Net6.Rest.Api.Model.Countries>();

            string jsonPath = _hostingEnvironment.ContentRootPath + "\\JSON\\countries.json";

            using (StreamReader sr = new StreamReader(jsonPath))
            {
                var GetAllCountries = JsonConvert.DeserializeObject<List<Countries.States.Cities.Net6.Rest.Api.Model.Countries>>(sr.ReadToEnd());

                if (GetAllCountries != null)
                {
                    retVal.Result = true;
                    retVal.ResultCode = 200;
                    retVal.Message = "İşlem Başarılı";
                    retVal.Comment = GetAllCountries.Count + " Ülke Bulundu";
                    retVal.Data = GetAllCountries;
                    retVal.UpdateTime = DateTime.Now.ToString();
                }
                else
                {
                    retVal.Result = false;
                    retVal.ResultCode = -1;
                    retVal.Message = "Hata";
                    retVal.Comment = "Veriye Ulaşılamadı.";
                }
            }

            return retVal;
        }

        [Route("GetCountries/{CountriesId}")]
        public Response<Countries.States.Cities.Net6.Rest.Api.Model.Countries> GetCountriesByID(int CountriesId)
        {
            Response<Countries.States.Cities.Net6.Rest.Api.Model.Countries> retVal = new Response<Countries.States.Cities.Net6.Rest.Api.Model.Countries>();

            string jsonPath = _hostingEnvironment.ContentRootPath + "\\JSON\\countries.json";

            using (StreamReader sr = new StreamReader(jsonPath))
            {
                var GetCountries = JsonConvert.DeserializeObject<List<Countries.States.Cities.Net6.Rest.Api.Model.Countries>>(sr.ReadToEnd()).Where(x => x.id == CountriesId);

                if (CountriesId == 0)
                {
                    retVal.Result = false;
                    retVal.ResultCode = -1;
                    retVal.Message = "Lütfen Ülke idsini giriniz.";
                    retVal.Comment = "Veriye Ulaşılamadı.";
                }
                else
                {
                    if (GetCountries != null)
                    {
                        retVal.Result = true;
                        retVal.ResultCode = 200;
                        retVal.Message = "İşlem Başarılı";
                        retVal.Comment = "";
                        retVal.Data = GetCountries;
                        retVal.UpdateTime = DateTime.Now.ToString();
                    }
                    else
                    {
                        retVal.Result = false;
                        retVal.ResultCode = -1;
                        retVal.Message = "Hata";
                        retVal.Comment = "Veriye Ulaşılamadı.";
                    }
                }
            }

            return retVal;
        }

        [Route("GetStates/{CountriesId}")]
        public Response<Countries.States.Cities.Net6.Rest.Api.Model.States> GetStatesByID(int CountriesId)
        {
            Response<Countries.States.Cities.Net6.Rest.Api.Model.States> retVal = new Response<Countries.States.Cities.Net6.Rest.Api.Model.States>();

            string jsonPath = _hostingEnvironment.ContentRootPath + "\\JSON\\states.json";

            using (StreamReader sr = new StreamReader(jsonPath))
            {
                var GetStates = JsonConvert.DeserializeObject<List<Countries.States.Cities.Net6.Rest.Api.Model.States>>(sr.ReadToEnd()).Where(x => x.country_id == CountriesId);

                if (CountriesId == 0)
                {
                    retVal.Result = false;
                    retVal.ResultCode = -1;
                    retVal.Message = "Lütfen Ülke idsini giriniz.";
                    retVal.Comment = "Veriye Ulaşılamadı.";
                }
                else

           if (GetStates != null)
                {
                    retVal.Result = true;
                    retVal.ResultCode = 200;
                    retVal.Message = "İşlem Başarılı";
                    retVal.Comment = GetStates.Count() + " il Bulundu";
                    retVal.Data = GetStates;
                    retVal.UpdateTime = DateTime.Now.ToString();
                }
                else
                {
                    retVal.Result = false;
                    retVal.ResultCode = -1;
                    retVal.Message = "Hata";
                    retVal.Comment = "Veriye Ulaşılamadı.";
                }
            }

            return retVal;
        }

        [Route("GetCities/{StatesId}")]
        public Response<Countries.States.Cities.Net6.Rest.Api.Model.Cities> GetCitiesByID(int StatesID)
        {
            Response<Countries.States.Cities.Net6.Rest.Api.Model.Cities> retVal = new Response<Countries.States.Cities.Net6.Rest.Api.Model.Cities>();

            string jsonPath = _hostingEnvironment.ContentRootPath + "\\JSON\\cities.json";

            using (StreamReader sr = new StreamReader(jsonPath))
            {
                var GetCities = JsonConvert.DeserializeObject<List<Countries.States.Cities.Net6.Rest.Api.Model.Cities>>(sr.ReadToEnd()).Where(x => x.state_id == StatesID);

                if (GetCities != null)
                {
                    retVal.Result = true;
                    retVal.ResultCode = 200;
                    retVal.Message = "İşlem Başarılı";
                    retVal.Comment = GetCities.Count() + " ilçe Bulundu";
                    retVal.Data = GetCities;
                    retVal.UpdateTime = DateTime.Now.ToString();
                }
                else
                {
                    retVal.Result = false;
                    retVal.ResultCode = -1;
                    retVal.Message = "Hata";
                    retVal.Comment = "Veriye Ulaşılamadı.";
                }
            }

            return retVal;
        }
    }
}