//using Newtonsoft.Json.Converters;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.IO.Compression;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using XamarinMauiProject.Models;

//namespace XamarinMauiProject.Services
//{
//    public class myHttpClient : IDisposable
//    {
//#pragma warning disable 219
//        #region Variables
//        private bool disposing = false;
//        //   private string prv_fncName ="";
//        #endregion

//        #region myHttpClient
//        public myHttpClient()
//        {
//            //prv_fncName = functionName;
//        }
//        #endregion

//        #region Dispose
//        public void Dispose()
//        {
//            try
//            {
//                if (disposing)
//                    return;
//                disposing = true;
//                GC.SuppressFinalize(this);
//            }
//            catch
//            {
//                throw;
//            }
//        }
//        #endregion

//        #region GetRequest
//        public async Task<List<Object>> GetRequest<T>(string url)
//        {
//            try
//            {
//                HttpClientHandler handler = new HttpClientHandler()
//                {
//                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
//                };

//                List<object> lst_Obj = new List<object>();
//                using (var client = new HttpClient(handler))
//                {
//                    client.BaseAddress = new Uri(APIs.AuthenticateUser);
//                    client.DefaultRequestHeaders.Accept.Clear();
//                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                    client.DefaultRequestHeaders.Add("connection", "keep-alive");
//                    client.DefaultRequestHeaders.Add("Content-Encodingg", "gzip");
//                    client.DefaultRequestHeaders.Add("accept-charset", "utf-8");


//                    using (var r = await client.GetAsync(url))
//                    {
//                        if (r.StatusCode == HttpStatusCode.OK)
//                        {
//                            byte[] result = await r.Content.ReadAsByteArrayAsync();
//                            byte[] decompress = DecompressA(result);
//                            string text = System.Text.ASCIIEncoding.UTF8.GetString(decompress);
//                            var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(text));
//                            var value = await task;
//                            lst_Obj.Add("200");
//                            lst_Obj.Add(value);
//                            return lst_Obj;

//                        }
//                        else if (r.StatusCode == HttpStatusCode.BadRequest)
//                        {
//                            byte[] result = await r.Content.ReadAsByteArrayAsync();
//                            byte[] decompress = DecompressA(result);
//                            string text = System.Text.ASCIIEncoding.UTF8.GetString(decompress);
//                            var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<dynamic>(text));
//                            var value = await task;
//                            lst_Obj.Add("400");
//                            //  lst_Obj.Add(value.Message);
//                            return lst_Obj;
//                        }

//                        else
//                        {
//                            throw new Exception(r.Content.ReadAsStringAsync().Result);
//                        }

//                    }
//                }

//            }
//            catch
//            {
//                throw;
//            }
//            finally
//            {

//            }
//        }
//        #endregion



//        #region DecompressA
//        static byte[] DecompressA(byte[] gzip)
//        {
//            // Create a GZIP stream with decompression mode.
//            // ... Then create a buffer and write into while reading from the GZIP stream.
//            using (GZipStream stream = new GZipStream(new MemoryStream(gzip),
//                CompressionMode.Decompress))
//            {
//                const int size = 4096;
//                byte[] buffer = new byte[size];
//                using (MemoryStream memory = new MemoryStream())
//                {
//                    int count = 0;
//                    do
//                    {
//                        count = stream.Read(buffer, 0, size);
//                        if (count > 0)
//                        {
//                            memory.Write(buffer, 0, count);
//                        }
//                    }
//                    while (count > 0);
//                    return memory.ToArray();
//                }
//            }
//        }
//        #endregion



//        #region GetRequestA
//        public async Task<T> GetRequestA<T>(string url)
//        {
//            try
//            {
//                HttpClientHandler handler = new HttpClientHandler()
//                {
//                    Proxy = null,
//                    UseProxy = false,
//                    AutomaticDecompression = DecompressionMethods.GZip
//                };

//                using (var client = new HttpClient(handler))
//                {
//                    client.BaseAddress = new Uri(APIs.AuthenticateUser);
//                    client.DefaultRequestHeaders.Accept.Clear();
//                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                    client.DefaultRequestHeaders.Add("connection", "keep-alive");
//                    client.DefaultRequestHeaders.Add("accept-encoding", "gzip");
//                    client.DefaultRequestHeaders.Add("accept-charset", "utf-8");
//                    client.Timeout = TimeSpan.FromMinutes(1);
//                    using (var r = await client.GetAsync(url))
//                    {
//                        if (r.IsSuccessStatusCode)
//                        {
//                            byte[] result = await r.Content.ReadAsByteArrayAsync();
//                            byte[] decompress = DecompressA(result);
//                            string text = System.Text.ASCIIEncoding.UTF8.GetString(decompress);
//                            var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(text));
//                            var value = await task;
//                            return value;
//                        }
//                        else
//                        {
//                            byte[] result = await r.Content.ReadAsByteArrayAsync();
//                            byte[] decomp = DecompressA(result);

//                            string text = System.Text.ASCIIEncoding.UTF8.GetString(decomp);

//                            //ExpandoObject cust = JsonConvert.DeserializeObject<ExpandoObject>(result, new ExpandoObjectConverter());
//                            //string a = cust.Where(x => x.Key == "Message").Select(x => x.Value).FirstOrDefault().ToString();
//                            throw new Exception(text);
//                        }
//                    }
//                }

//            }
//            catch
//            {
//                throw;
//            }
//            finally
//            {

//            }
//        }
//        #endregion




//        #region PostRequestZ
//        public async Task<List<Object>> PostRequestZ<T>(string url, Object obj)
//        {


//            try
//            {
//                List<object> lst_Obj = new List<object>();
//                Newtonsoft.Json.JsonSerializerSettings json = new Newtonsoft.Json.JsonSerializerSettings();
//                json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
//                json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
//                json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
//                json.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
//                json.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
//                json.Formatting = Formatting.Indented;

//                string str = JsonConvert.SerializeObject(obj, Formatting.Indented, json);

//                HttpClientHandler handler = new HttpClientHandler()
//                {
//                    Proxy = null,
//                    UseProxy = false,
//                    UseCookies = true,

//                };

//                using (HttpClient client = new HttpClient(handler))
//                {
//                    client.MaxResponseContentBufferSize = 256000;
//                    client.Timeout = TimeSpan.FromSeconds(10000);
//                    client.BaseAddress = new Uri(APIs.AuthenticateUser);
//                    client.DefaultRequestHeaders.Accept.Clear();
//                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                    using (var r = await client.PostAsync(url, new StringContent(str, Encoding.UTF8, "application/json")))
//                    {
//                        if (r.IsSuccessStatusCode)
//                        {
//                            string result = await r.Content.ReadAsStringAsync();
//                            lst_Obj.Add("200");
//                            lst_Obj.Add(JsonConvert.DeserializeObject<T>(result));
//                            return lst_Obj;
//                        }
//                        else if (r.StatusCode == HttpStatusCode.BadRequest)
//                        {
//                            string result = await r.Content.ReadAsStringAsync();
//                            lst_Obj.Add("400");
//                            ExpandoObject cust = JsonConvert.DeserializeObject<ExpandoObject>(result, new ExpandoObjectConverter());
//                            string a = cust.Where(x => x.Key == "Message").Select(x => x.Value).FirstOrDefault().ToString();
//                            lst_Obj.Add(a);
//                            return lst_Obj;
//                        }
//                        else if (r.StatusCode == HttpStatusCode.NotFound)
//                        {
//                            string result = await r.Content.ReadAsStringAsync();
//                            lst_Obj.Add("404");
//                            ExpandoObject cust = JsonConvert.DeserializeObject<ExpandoObject>(result, new ExpandoObjectConverter());
//                            string a = cust.Where(x => x.Key == "Message").Select(x => x.Value).FirstOrDefault().ToString();
//                            lst_Obj.Add(a);
//                            return lst_Obj;
//                        }


//                        else
//                        {
//                            throw new Exception(r.Content.ReadAsStringAsync().Result);
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                string a = ex.Message;
//                throw;
//            }
//            finally
//            {


//            }
//        }
//        #endregion



//    }
//}
