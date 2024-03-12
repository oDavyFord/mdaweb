using MDA_Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Web.Util;
using System.Web.Routing;
using System.Reflection.Emit;

namespace MDA_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["TransferenciaActiva"] != null || Session["TransferenciaActiva"] == null)
            {
                Session.Abandon();
                Session[""] = null;
            }
            return View();
        }
        [Route("beneficios")]
        public ActionResult Beneficios()
        {
            if (Session["TransferenciaActiva"] != null)
            {
                Session.Abandon();
                Session["UserName"] = null;

            }
            return View();
        }

        public ActionResult Alianzas( AlianzaModel model)
        {
            if (Session["TransferenciaActiva"] != null)
            {
                Session.Abandon();
                Session["UserName"] = null;

            }

            model.nombreEstado = ObtenerNombreEstado(model.estadoid); 
            if(model.estadoid != null)
            {
                model.mostrarMunicipios = true;
            }
            else
            {
                model.mostrarMunicipios = false;
            }
            return View(model);
        }
        private string ObtenerNombreEstado(int? estadoId)
        {
            switch (estadoId)
            {
                case 1:
                    return "AGUASCALIENTES";
                case 2:
                    return "BAJA CALIFORNIA";
                case 3:
                    return "BAJA CALIFORNIA SUR";
                case 4:
                    return "CAMPECHE";
                case 5:
                    return "COAHUILA";
                case 6:
                    return "COLIMA";
                case 7:
                    return "CHIAPAS";
                case 8:
                    return "CHIHUAHUA";
                case 9:
                    return "CDMX [DF]";
                case 10:
                    return "DURANGO";
                case 11:
                    return "GUANAJUATO";
                case 12:
                    return "GUERRERO";
                case 13:
                    return "HIDALGO";
                case 14:
                    return "JALISCO";
                case 15:
                    return "MEXICO";
                case 16:
                    return "MICHOACAN";
                case 17:
                    return "MORELOS";
                case 18:
                    return "NAYARIT";
                case 19:
                    return "NUEVO LEON";
                case 20:
                    return "OAXACA";
                case 21:
                    return "PUEBLA";
                case 22:
                    return "QUERETARO";
                case 23:
                    return "QUINTANA ROO";
                case 24:
                    return "SAN LUIS POTOSI";
                case 25:
                    return "SINALOA";
                case 26:
                    return "SONORA";
                case 27:
                    return "TABASCO";
                case 28:
                    return "TAMAULIPAS";
                case 29:
                    return "TLAXCALA";
                case 30:
                    return "VERACRUZ";
                case 31:
                    return "YUCATAN";
                case 32:
                    return "ZACATECAS";
                case 99:
                    return "EXTRANJERO";
                default:
                    return "Estado Desconocido";
            }
        }


        public ActionResult Faq()
        {
            if (Session["TransferenciaActiva"] != null)
            {
                Session.Abandon();
                Session["UserName"] = null;

            }
            return View();
        }

        public ActionResult Faq_02()
        {
            return View();
        }

        public ActionResult Faq_03()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            if (Session["TransferenciaActiva"] != null)
            {
                Session.Abandon();
                Session["UserName"] = null;

            }
            return View();
        }
        public ActionResult robo_extravio()
        {
            if (Session["TransferenciaActiva"] != null)
            {
                Session.Abandon();
                Session["UserName"] = null;

            }
            return View();
        }
        public ActionResult inicio()
        {
            if (Session["TransferenciaActiva"] != null)
            {
                Session.Abandon();
                Session["UserName"] = null;

            }
           

            ViewBag.secretkeyv2 = ConfigurationManager.AppSettings["secretkeyv2"];
            ViewBag.sitekeyv2 = ConfigurationManager.AppSettings["sitekeyv2"];
            return View();

            

           
        }
        public ActionResult saldo()
        {
            if (Session["TransferenciaActiva"] != null)
            {
                Session.Abandon();
                Session["UserName"] = null;

            }
            var saldo = TempData["TransaccionesConsultaModel"] as TransaccionesConsultaModel;

            if (saldo == null)
            {
                return RedirectToAction("transferencia_exito");

            }
            return View(saldo);

        }

        public ActionResult transacciones_consulta()
        {
            if (Session["TransaccionesConsultaModel"] is TransaccionesConsultaModel TransaccionesConsultaModel)
            {
                ViewBag.UserName = TransaccionesConsultaModel.clienteNombre;
                string currentPage = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                if (string.IsNullOrEmpty(currentPage) || currentPage.Equals("index", StringComparison.OrdinalIgnoreCase) || currentPage.Equals("beneficios", StringComparison.OrdinalIgnoreCase) )
                {
                    Session.Abandon();
                }



                return View(TransaccionesConsultaModel);
            }
            else
            {
                return RedirectToAction("inicio");
            }
        }


        public ActionResult detalle_Ticket()
        {
            var detallesTicket = TempData["DetallesTicket"] as ResponseTicketModel;
            if (detallesTicket == null)
            {

                return RedirectToAction("transacciones_consulta");
            }
            return View(detallesTicket);

        }

        public ActionResult Pruebas() {

            try
            {
                if (ModelState.IsValid)
                {
                    var client = new System.Net.WebClient();

                    //string PrivateKey = "6LcH-v8SerfgAPlLLffghrITSL9xM7XLrz8aeory";

                    var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify"));

                    TempData["ErrorMessage"] = GoogleReply;

                    var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptcha>(GoogleReply);
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                TempData["ErrorMessage"] = ex.Message;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SaveContacto")]
        public ActionResult SaveContacto(ContactoModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = SendForm(form);

                    if (result.errorid == 0)
                    {
                        TempData["Mensaje"] = 1;
                        TempData["ErrorId"] = result.errorid;
                        return RedirectToAction("Contacto");

                    }
                    else
                    {
                        return RedirectToAction("Contacto", new { Mensaje = result.errorid, ActionErrorId = result.errorid });

                    }
                }
                else
                {
                    ViewBag.Success = false;

                    return RedirectToAction("Contacto", new { Mensaje = 3, ActionErrorId = 3 });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Contacto", new { Mensaje = 3, ActionErrorId = 3 });

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SaveInicio")]
        public ActionResult SaveInicio(InicioModel form)
        {
            string Secret = ConfigurationManager.AppSettings["SecretKey"];

            try
            {
                if (ModelState.IsValid)
                {
                    // Verifica Recaptcha
                    if (!string.IsNullOrEmpty(Request.Params["g-recaptcha-response"]))
                    {
                        string EncodedResponse = Request.Params["g-recaptcha-response"];
                        //bool IsCaptchaValid = (ReCaptcha.Validate(EncodedResponse, Secret) == "true");
                        string IsCaptchaValid = ReCaptcha.Validate(EncodedResponse, Secret);
                        switch (IsCaptchaValid)
                        {
                            case "false":
                                TempData["ErrorMessage"] = " * Captcha Incorrecto! " + ReCaptcha.MessageError.ToString();
                                return RedirectToAction("Inicio");
                            case "fail":
                                TempData["ErrorMessage"] = " * Falla Servicio Captcha! " + ReCaptcha.MessageError.ToString();
                                return RedirectToAction("Inicio");
                            default:
                                break;
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = " * Captcha Token Incorrecto!";

                        return RedirectToAction("Inicio");
                    }

                    var ipAddress = this.HttpContext.Request.UserHostAddress;

                    form.store = "1150";
                    form.pos = "website";
                    form.employee = ipAddress;
                    form.cardpassword = form.anio + form.mes + form.dia;


                    var result = SendFormInicio(form);

                    if (result.errorid == 0)
                    {
                        TempData["fechanacimiento"] = form.cardpassword;
                        TempData["tarjeta"] = form.card;
                        var TransaccionesConsultaModel = new TransaccionesConsultaModel
                        {
                            card = form.card,
                            store = "1150",
                            pos = "website",
                            employee = form.employee,
                            mes = form.mes,
                            dia = form.dia,
                            anio = form.anio,
                        }; 
                        var TransaccionesConsultaResult = SendFormTransaccionesConsulta(TransaccionesConsultaModel);

                        TransaccionesConsultaModel.Transactions = ProcessCardBalanceSheet(TransaccionesConsultaResult.cardbalancesheet);
                        TransaccionesConsultaModel.HtmlContent = TransaccionesConsultaResult.cardbalancesheet;

                        var saldosModel = new SaldoModel
                        {
                            sTarjeta = TransaccionesConsultaModel.card,
                            sSucId = "1150",
                            sCajaId = "website",
                            sTerminalId = TransaccionesConsultaModel.employee,
                        };

                        var saldosResult = SendFormSaldos(saldosModel);

                        TransaccionesConsultaModel.SaldoPuntos = saldosResult.saldoPuntos;
                        TransaccionesConsultaModel.SaldoDesglose1 = saldosResult.saldoDesglose1;
                        TransaccionesConsultaModel.SaldoDesglose2 = saldosResult.saldoDesglose2;
                        TransaccionesConsultaModel.clienteNombre= saldosResult.clienteNombre;
                        var planLealtad = new PlanesLealtadModel
                        {
                            cardnumber = TransaccionesConsultaModel.card,
                        };
                        var responsePlanLealtad = SendFormPlanLealtd(planLealtad);

                        TransaccionesConsultaModel.PlanesLealtad = responsePlanLealtad.historialapego;
                        TransaccionesConsultaModel.BonificacionesPendientes = responsePlanLealtad.bonuspending;


                        Session["TransaccionesConsultaModel"] = TransaccionesConsultaModel;
                        Session["UserName"] = TransaccionesConsultaModel.clienteNombre;
                        Session["fechanacimiento"] = form.cardpassword;
                        Session["tarjeta"] = form.card;
                        Session["Saldo"] = TransaccionesConsultaModel.SaldoPuntos;
                        Session["TransferenciaActiva"] = null;



                        HttpContext.Session.Timeout = 8;



                        return RedirectToAction("transacciones_consulta");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = result.errorid;
                        return RedirectToAction("Inicio");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Ocurrio un error, intentelo de nuevo";

                    return RedirectToAction("Inicio");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = (4);

                return RedirectToAction("Inicio");
            }
        }

        [HttpGet]
        [ActionName("DetalleTicket")]
        public ActionResult DetalleTicket(string cardnumber, string transactionid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TicketModel form = new TicketModel
                    {
                        cardnumber = cardnumber,
                        transactionid = transactionid
                    };

                    var result = SendFormTicket(form);

                    if (result.errorid == 0)
                    {
                        result.card = cardnumber;
                        TempData["DetallesTicket"] = result;
                        return RedirectToAction("Detalle_Ticket"); 
                    }
                    else
                    {
                        return RedirectToAction("transacciones_consulta", new { Mensaje = result.message, ActionErrorId = result.errorid });
                    }
                }
                else
                {
                    ViewBag.Success = false;
                    return RedirectToAction("transacciones_consulta", new { Mensaje = 3, ActionErrorId = 3 });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("transacciones_consulta", new { Mensaje = 3, ActionErrorId = 3 });
            }
        }

       // [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult transferencia_saldo()
        {
            ViewBag.secretkeyv2 = ConfigurationManager.AppSettings["secretkeyv2"];
            ViewBag.sitekeyv2 = ConfigurationManager.AppSettings["sitekeyv2"];
            //if (Session["TransferenciaActiva"] != null)
            //{
            //    Session.Abandon();
            //    Session["UserName"] = null;
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("transferencia_saldo_tarjeta");
            //}
            return View();

        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult transferencia_saldo_tarjeta()
        {
            TransferenciaTarjetaModel transferencia = new TransferenciaTarjetaModel();
            transferencia.fechanacimiento = Session["fechanacimiento"] as string;
            transferencia.tarjeta = Session["tarjeta"] as string;
            var saldo = Session["Saldo"] as string;
            if (saldo == null)
            {
                transferencia.saldo = Session["saldo2"] as string;
            }
            else
            {
                transferencia.saldo = Session["Saldo"] as string;

            }

            if (transferencia.fechanacimiento == null || transferencia.fechanacimiento == "")
            {
                return RedirectToAction("transferencia_saldo");
            }
            return View(transferencia);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult transferencia_saldo_datos()
        {
            TransferenciaModel transferencia = new TransferenciaModel();
            ViewBag.secretkeyv2 = ConfigurationManager.AppSettings["secretkeyv2"];
            ViewBag.sitekeyv2 = ConfigurationManager.AppSettings["sitekeyv2"];
            transferencia.fechanacimiento = Session["fechanacimiento"] as string;
            transferencia.saldo = Session["saldo"] as string;
            transferencia.tarjetaorigen = Session["tarjetaorigen"] as string;
            transferencia.tarjetadestino = Session["tarjetadestino"] as string;
            transferencia.permission = true;
            if(Session["UserName"] == null)
            {
                return RedirectToAction("transferencia_saldo");


            }

            return View(transferencia);
        }
        public ActionResult transferencia_saldo_exito()
        {
            TransferenciaDatosModel transferencia = new TransferenciaDatosModel();
            transferencia.saldo = TempData["saldo"] as string;
            transferencia.tarjetaorigen = TempData["tarjetaorigen"] as string;
            transferencia.tarjetadestino = TempData["tarjetadestino"] as string;
            transferencia.transactionid = TempData["transactionid"] as string;
            transferencia.fechanacimiento = TempData["FechaNacimiento"] as string;
            if(TempData["tarjetaorigen"] == null){
                Session.Abandon();
                Session["UserName"] = null;

                return RedirectToAction("transferencia_saldo");

            }

            Session.Abandon();
            

            return View(transferencia);
        }
       

        public ActionResult transferencia_saldo_error_datos()
        {
            TransferenciaDatosModel transferencia = new TransferenciaDatosModel();
            transferencia.saldo = TempData["saldo"] as string;
            transferencia.tarjetaorigen = TempData["tarjetaorigen"] as string;
            transferencia.tarjetadestino = TempData["tarjetadestino"] as string;
            if (TempData["tarjetaorigen"] == null)
            {
                Session.Abandon();
                return RedirectToAction("transferencia_saldo");

            }
            return View(transferencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SaveTransferenciaSaldo")]
        public ActionResult SaveTransferenciaSaldo(TransferenciaModel form)
        {
            string Secret = ConfigurationManager.AppSettings["SecretKey"];

            try
            {
                if (ModelState.IsValid)
                {
                    // Verifica Recaptcha
                    if (!string.IsNullOrEmpty(Request.Params["g-recaptcha-response"]))
                    {
                        string EncodedResponse = Request.Params["g-recaptcha-response"];
                        //bool IsCaptchaValid = (ReCaptcha.Validate(EncodedResponse, Secret) == "true");
                        string IsCaptchaValid = ReCaptcha.Validate(EncodedResponse, Secret);
                        switch (IsCaptchaValid)
                        {
                            case "false":
                                TempData["ErrorMessage"] = " * Captcha Incorrecto!";
                                return RedirectToAction("transferencia_saldo");
                            case "fail":
                                TempData["ErrorMessage"] = " * Falla Servicio Captcha!";
                                return RedirectToAction("transferencia_saldo");
                            default:
                                break;
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = " * Captcha Token Incorrecto!";

                        return RedirectToAction("transferencia_saldo");
                    }

                    var ipAddress = this.HttpContext.Request.UserHostAddress;

                    form.store = "1150";
                    form.pos = "website";
                    form.employee = ipAddress;
                    form.cardpassword =    form.anio+ form.mes+ form.dia;

                    var result = SendFormTransferencia(form);

                    if (result.errorid == 0)
                    {
                        var saldosModel = new SaldoModel
                        {
                            sTarjeta = form.tarjeta,
                            sSucId = "1150",
                            sCajaId = "website",
                            sTerminalId =ipAddress.ToString(),
                        };

                        var saldosResult = SendFormSaldos(saldosModel);
                        Session["saldo2"] = result.cardbalance;
                        Session["UserName"] = saldosResult.clienteNombre;
                        Session["fechanacimiento"] = form.cardpassword;
                        Session["tarjeta"] = form.tarjeta;
                        Session["TransferenciaActiva"] = true;
                        HttpContext.Session.Timeout = 8;

                        return RedirectToAction("transferencia_saldo_tarjeta");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = result.errorid;
                        return RedirectToAction("transferencia_saldo");
                       // return RedirectToAction("transferencia_saldo_error_datos", new { Mensaje = result.errorid, ActionErrorId = result.errorid });
                    }
                }
                else
                {
                    ViewBag.Success = false;
                    return RedirectToAction("transferencia_saldo_error_datos", new { Mensaje = 3, ActionErrorId = 3 });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("transferencia_saldo_error_datos", new { Mensaje = 3, ActionErrorId = 3 });
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SaveTransferenciaSaldoTarjeta")]
        public ActionResult SaveTransferenciaSaldoTarjeta(TransferenciaTarjetaModel form)
        {
            var recaptchaResponse = Request.Form.ToString(); 
            Debug.WriteLine(recaptchaResponse);
            try
            {
                if (ModelState.IsValid)
                {
                    var ipAddress = this.HttpContext.Request.UserHostAddress;
                  
                    var valdiation1 = new InicioModel
                    {
                        card = form.tarjetaorigen,
                        cardpassword = form.fechanacimiento,
                        store = "1150",
                        pos = "website",
                        employee = ipAddress,

                    };

                    var valdiation2 = new InicioModel
                    {
                        card = form.tarjetadestino,
                        cardpassword = form.fechanacimiento,
                        store = "1150",
                        pos = "website",
                        employee = ipAddress,

                    };

                    var  ValidateOriginCard = SendFormInicio(valdiation1);
                    var ValidateDestinationCard = SendFormInicio(valdiation2);
                    if (ValidateOriginCard.errorid == 0)
                    {
                        if(ValidateDestinationCard.errorid == 0)
                        {
                            var saldosModel = new SaldoModel
                            {
                                sTarjeta = form.tarjetaorigen,
                                sSucId = "1150",
                                sCajaId = "website",
                                sTerminalId = ipAddress
                            };
                            var saldosResult = SendFormSaldos(saldosModel);

                            Session["fechanacimiento"] = form.fechanacimiento;
                            Session["tarjetadestino"] = form.tarjetadestino;
                            Session["tarjetaorigen"] = form.tarjetaorigen;
                            Session["saldo"] = saldosResult.saldoPuntos;
                            Session["pr"] = form.nombre;
                            return RedirectToAction("transferencia_saldo_datos", new { });


                        }
                        else
                        {
                            TempData["tarjetaorigen"] = form.tarjetaorigen;
                            TempData["tarjetadestino"] = form.tarjetadestino;
                            TempData["Mensaje"] = "Tarjeta de destino inválida";

                            return RedirectToAction("transferencia_saldo_error_datos");

                        }
                       
                    }
                    TempData["tarjetaorigen"] = form.tarjetaorigen;
                    TempData["tarjetadestino"] = form.tarjetadestino;
                    TempData["Mensaje"] = "Tarjeta de origen inválida";

                    return RedirectToAction("transferencia_saldo_error_datos");

                }
                else
                {
                    ViewBag.Success = false;
                    return RedirectToAction("transferencia_saldo_tarjeta", new { Mensaje = 3, ActionErrorId = 3 });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("transferencia_saldo_tarjeta", new { Mensaje = 3, ActionErrorId = 3 });

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SaveTransferenciaSaldoDatos")]
        public ActionResult SaveTransferenciaSaldoDatos(TransferenciaDatosModel form)
        {
            //var recaptchaResponse = Request.Form.ToString(); 
            try
            {
                if (ModelState.IsValid)
                {
                    form.store = "1150";
                    form.pos = "website";
                    var ipAddress = this.HttpContext.Request.UserHostAddress;
                    form.employee = ipAddress;
                    var result = SendFormTransferenciaDatos(form);


                    if (result.errorid == 0)
                    {
                        if (form.saldo == "0")
                        {
                            return RedirectToAction("transferencia_saldo_error_datos");
                        }
                        TempData["tarjetadestino"] = form.tarjetadestino;
                        TempData["tarjetaorigen"] = form.tarjetaorigen;
                        TempData["saldo"] = form.saldo;
                        TempData["transactionid"] = result.transactionid;
                        TempData["FechaNacimiento"] = form.anio + form.mes + form.dia;


                        return RedirectToAction("transferencia_saldo_exito");
                    }
                    else
                    {
                        TempData["tarjetadestino"] = form.tarjetadestino;
                        TempData["tarjetaorigen"] = form.tarjetaorigen;
                        TempData["saldo"] = form.saldo;
                        return RedirectToAction("transferencia_saldo_error_datos", new { Mensaje = result.message, ActionErrorId = result.errorid });
                    }
                }
                else
                {
                    ViewBag.Success = false;
                    return RedirectToAction("transferencia_saldo_datos", new { Mensaje = 3, ActionErrorId = 3 });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("transferencia_saldo_error_datos", new { Mensaje = 3, ActionErrorId = 3 });
            }
        }

        public ResponseLoginModel SendFormInicio(InicioModel requestApi)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["login"];
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "application/xml";

                requestApi.authcode = ConfigurationManager.AppSettings["KEY_ID"];

                var postData = $"authcode={HttpUtility.UrlEncode(requestApi.authcode)}" +
                               $"&card={HttpUtility.UrlEncode(requestApi.card)}" +
                               $"&cardpassword={HttpUtility.UrlEncode(requestApi.cardpassword)}" +
                               $"&store={HttpUtility.UrlEncode(requestApi.store)}" +
                               $"&pos={HttpUtility.UrlEncode(requestApi.pos)}" +
                               $"&employee={HttpUtility.UrlEncode(requestApi.employee)}";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultXml = streamReader.ReadToEnd();

                    var xmlDoc = XDocument.Parse(resultXml);
                    var errorId = int.Parse(xmlDoc.Descendants("ERRORID").FirstOrDefault()?.Value ?? "-1");
                    var message = xmlDoc.Descendants("MESSAGE").FirstOrDefault()?.Value;
                    var operationDate = xmlDoc.Descendants("OPERATIONDATE").FirstOrDefault()?.Value;
                    var cardbalance = xmlDoc.Descendants("CARDBALANCE").FirstOrDefault()?.Value;

                    var result = new ResponseLoginModel
                    {
                        errorid = errorId,
                        message = message,
                        operationdate = operationDate,
                        cardbalance = cardbalance,
                    };

                    return result;
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        public ResponseTransaccionesConsultaModel SendFormTransaccionesConsulta(TransaccionesConsultaModel requestApi)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["getCardBalanceSheet"];
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "application/xml";

                requestApi.authcode = ConfigurationManager.AppSettings["KEY_ID"];

                var postData = $"authcode={HttpUtility.UrlEncode(requestApi.authcode)}" +
                               $"&card={HttpUtility.UrlEncode(requestApi.card)}" +
                               $"&store={HttpUtility.UrlEncode(requestApi.store)}" +
                               $"&pos={HttpUtility.UrlEncode(requestApi.pos)}" +
                               $"&employee={HttpUtility.UrlEncode(requestApi.employee)}";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultXml = streamReader.ReadToEnd();

                    var xmlDoc = XDocument.Parse(resultXml);
                    var transactionId = xmlDoc.Descendants("TRANSACTIONID").FirstOrDefault()?.Value;//
                    var card = xmlDoc.Descendants("CARD").FirstOrDefault()?.Value;
                    var cardbalancesheet = xmlDoc.Descendants("CARDBALANCESHEET").FirstOrDefault()?.Value;
                    var errorId = int.Parse(xmlDoc.Descendants("ERRORID").FirstOrDefault()?.Value ?? "-1");//
                    var message = xmlDoc.Descendants("MESSAGE").FirstOrDefault()?.Value;//
                    var operationDate = xmlDoc.Descendants("OPERATIONDATE").FirstOrDefault()?.Value;//

                    var result = new ResponseTransaccionesConsultaModel
                    {
                        errorid = errorId,
                        message = message,
                        operationdate = operationDate,
                        transactionid = transactionId,
                        card = card,
                        cardbalancesheet = cardbalancesheet,
                    };

                    return result;
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        public ResponseSaldosModel SendFormSaldos(SaldoModel requestApi)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["getSaldos"];
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "application/xml";

                requestApi.sAuthCode = ConfigurationManager.AppSettings["KEY_ID"];

                var postData = $"sTarjeta={HttpUtility.UrlEncode(requestApi.sTarjeta)}" +
                               $"&sSucId={HttpUtility.UrlEncode(requestApi.sSucId)}" +
                               $"&sCajaId={HttpUtility.UrlEncode(requestApi.sCajaId)}" +
                               $"&sTerminalId={HttpUtility.UrlEncode(requestApi.sTerminalId)}" +
                               $"&sAuthCode={HttpUtility.UrlEncode(requestApi.sAuthCode)}";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultXml = streamReader.ReadToEnd();

                    var xmlDoc = XDocument.Parse(resultXml);
                    var SESSION_ID = xmlDoc.Descendants("SESSION_ID").FirstOrDefault()?.Value;//
                    var CLIENTENOMBRE = xmlDoc.Descendants("CLIENTENOMBRE").FirstOrDefault()?.Value;
                    var SALDO_PUNTOS = xmlDoc.Descendants("SALDO_PUNTOS").FirstOrDefault()?.Value;
                    var SALDO_DESGLOSE1 = decimal.Parse(xmlDoc.Descendants("SALDO_DESGLOSE1").FirstOrDefault()?.Value);
                    var SALDO_DESGLOSE2 = decimal.Parse(xmlDoc.Descendants("SALDO_DESGLOSE2").FirstOrDefault()?.Value);
                    var SALDO1 = SALDO_DESGLOSE1.ToString("F2");
                    var SALDO2 = SALDO_DESGLOSE2.ToString("F2");
                    var MSGERR = int.Parse(xmlDoc.Descendants("MSGERR").FirstOrDefault()?.Value ?? "-1");
                    var MENSAJE = xmlDoc.Descendants("MENSAJE").FirstOrDefault()?.Value;

                    var result = new ResponseSaldosModel
                    {
                        sessionId = SESSION_ID,
                        clienteNombre = CLIENTENOMBRE,
                        saldoPuntos = SALDO_PUNTOS,
                        saldoDesglose1 = SALDO1,
                        saldoDesglose2 = SALDO2,
                        errorid = MSGERR,
                        mensaje = MENSAJE


                    };

                    return result;
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }
        private List<TransactionModel> ProcessCardBalanceSheet(string cardBalanceSheet)
        {
            var transactions = new List<TransactionModel>();

            if (!string.IsNullOrEmpty(cardBalanceSheet))
            {
                var rows = cardBalanceSheet.Split('|');

                foreach (var row in rows)
                {
                    var columns = row.Split(',');

                    if (columns.Length == 7)
                    {
                        TicketModel form = new TicketModel
                        {
                            cardnumber = "1234567890123",
                            transactionid = columns[6]
                        };

                        transactions.Add(new TransactionModel
                        {
                            TipoMovimiento = columns[0],
                            Invoice = columns[1],
                            NoSucursal = columns[2],
                            NombreSucursal = SendFormTicket(form).store,
                            Fecha = (columns[3]),
                            Abono = decimal.Parse(columns[4]),
                            Cargo = decimal.Parse(columns[5]),
                            TransactionId = columns[6]
                        });
                    }

                }
            }

            return transactions;
        }
        public ResponseTicketModel SendFormTicket(TicketModel requestApi)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["getTransactionContent"];
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                requestApi.key = ConfigurationManager.AppSettings["KEY_ID"];

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(requestApi);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultString = streamReader.ReadToEnd();

                    var jsonStartIndex = resultString.IndexOf('{');

                    if (jsonStartIndex != -1)
                    {
                        var validJson = resultString.Substring(jsonStartIndex);

                        var result = JsonConvert.DeserializeObject<ResponseTicketModel>(validJson);

                        return result;
                    }
                }

                return null;
            }
            catch (WebException ex)
            {

                return null;
            }
        }
        //Servicio para contacto
        public ResponseModel SendForm(ContactoModel requestApi)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["siteContacto"];
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                requestApi.key = ConfigurationManager.AppSettings["KEY_ID"];

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(requestApi);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultString = streamReader.ReadToEnd();

                    var jsonStartIndex = resultString.IndexOf('{');

                    if (jsonStartIndex != -1)
                    {
                        var validJson = resultString.Substring(jsonStartIndex);

                        var result = JsonConvert.DeserializeObject<ResponseModel>(validJson);

                        return result;
                    }
                }

                return null;
            }
            catch (WebException ex)
            {

                return null;
            }
        }

        public ResponseLoginModel SendFormTransferencia(TransferenciaModel requestApi)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["login"];
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "application/xml";

                requestApi.authcode = ConfigurationManager.AppSettings["KEY_ID"];

                var postData = $"authcode={HttpUtility.UrlEncode(requestApi.authcode)}" +
                               $"&card={HttpUtility.UrlEncode(requestApi.tarjeta)}" +
                               $"&cardpassword={HttpUtility.UrlEncode(requestApi.cardpassword)}" + //ddmmaaaa
                               $"&store={HttpUtility.UrlEncode(requestApi.store)}" +
                               $"&pos={HttpUtility.UrlEncode(requestApi.pos)}" +
                               $"&employee={HttpUtility.UrlEncode(requestApi.employee)}";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultXml = streamReader.ReadToEnd();

                    var xmlDoc = XDocument.Parse(resultXml);
                    var errorId = int.Parse(xmlDoc.Descendants("ERRORID").FirstOrDefault()?.Value ?? "-1");
                    var message = xmlDoc.Descendants("MESSAGE").FirstOrDefault()?.Value;
                    var operationDate = xmlDoc.Descendants("OPERATIONDATE").FirstOrDefault()?.Value;
                    var cardbalance = xmlDoc.Descendants("CARDBALANCE").FirstOrDefault()?.Value;

                    var result = new ResponseLoginModel
                    {
                        errorid = errorId,
                        message = message,
                        operationdate = operationDate,
                        cardbalance = cardbalance,
                    };

                    return result;
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        public ResponseCardTransferModel SendFormTransferenciaDatos(TransferenciaDatosModel requestApi)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["setCardTransfer"];
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "application/xml";

                requestApi.authcode = ConfigurationManager.AppSettings["KEY_ID"];

                var postData = $"&cardfrom={HttpUtility.UrlEncode(requestApi.tarjetaorigen)}" +
                               $"&card={HttpUtility.UrlEncode(requestApi.tarjetadestino)}" +
                               $"&cardbirthdate={HttpUtility.UrlEncode(requestApi.fechanacimiento)}" +
                               $"&cardemail={HttpUtility.UrlEncode(requestApi.email)}" +
                               $"&cardphone={HttpUtility.UrlEncode(requestApi.celular)}" +
                               $"&store={HttpUtility.UrlEncode(requestApi.store)}" +
                               $"&pos={HttpUtility.UrlEncode(requestApi.pos)}" +
                               $"&employee={HttpUtility.UrlEncode(requestApi.employee)}" +
                               $"&authcode={HttpUtility.UrlEncode(requestApi.authcode)}";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultXml = streamReader.ReadToEnd();

                    var xmlDoc = XDocument.Parse(resultXml);
                    var transactionId = xmlDoc.Descendants("TRANSACTIONID").FirstOrDefault()?.Value;
                    var cardFrom = xmlDoc.Descendants("CARDFROM").FirstOrDefault()?.Value;
                    var card = xmlDoc.Descendants("CARD").FirstOrDefault()?.Value;
                    var cardBalance = xmlDoc.Descendants("CARDBALANCE").FirstOrDefault()?.Value;
                    var errorId = int.Parse(xmlDoc.Descendants("ERRORID").FirstOrDefault()?.Value ?? "-1");
                    var message = xmlDoc.Descendants("MESSAGE").FirstOrDefault()?.Value;
                    var operationDate = xmlDoc.Descendants("OPERATIONDATE").FirstOrDefault()?.Value;

                    var result = new ResponseCardTransferModel
                    {
                        errorid = errorId,
                        message = message,
                        operationdate = operationDate,
                        transactionid = transactionId,
                        cardfrom = cardFrom,
                        card = card,
                        cardbalance = cardBalance,
                    };

                    return result;
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SaveSaldo")]
        public ActionResult SaveSaldo(InicioModel form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ipAddress = this.HttpContext.Request.UserHostAddress;

                    form.store = "1150";
                    form.pos = "website";
                    form.employee = ipAddress;
                    form.cardpassword = form.anio + form.mes + form.dia;


                    var result = SendFormInicio(form);

                    if (result.errorid == 0)
                    {
                        TempData["fechanacimiento"] = form.cardpassword;
                        TempData["tarjeta"] = form.card;
                        var TransaccionesConsultaModel = new TransaccionesConsultaModel
                        {
                            card = form.card,
                            store = "1150",
                            pos = "website",
                            employee = form.employee,
                            mes = form.mes,
                            dia = form.dia,
                            anio = form.anio,
                        };
                        var TransaccionesConsultaResult = SendFormTransaccionesConsulta(TransaccionesConsultaModel);

                        TransaccionesConsultaModel.Transactions = ProcessCardBalanceSheet(TransaccionesConsultaResult.cardbalancesheet);
                        TransaccionesConsultaModel.HtmlContent = TransaccionesConsultaResult.cardbalancesheet;

                        var saldosModel = new SaldoModel
                        {
                            sTarjeta = TransaccionesConsultaModel.card,
                            sSucId = "1150",
                            sCajaId = "website",
                            sTerminalId = TransaccionesConsultaModel.employee,
                        };

                        var saldosResult = SendFormSaldos(saldosModel);

                        TransaccionesConsultaModel.SaldoPuntos = saldosResult.saldoPuntos;
                        TransaccionesConsultaModel.SaldoDesglose1 = saldosResult.saldoDesglose1;
                        TransaccionesConsultaModel.SaldoDesglose2 = saldosResult.saldoDesglose2;
                        TransaccionesConsultaModel.clienteNombre = saldosResult.clienteNombre;

                        //TempData["TransaccionesConsultaModel"] = TransaccionesConsultaModel;
                        //TempData["UserName"] = TransaccionesConsultaModel.clienteNombre;
                        TempData["TransaccionesConsultaModel"] = TransaccionesConsultaModel;
                        TempData["UserName"] = TransaccionesConsultaModel.clienteNombre;
                        //Session["fechanacimiento"] = form.cardpassword;
                        TempData["tarjeta"] = form.card;
                        TempData["Saldo"] = TransaccionesConsultaModel.SaldoPuntos;


                        //HttpContext.Session.Timeout = 8;



                        return RedirectToAction("Saldo");

                    }
                    else
                    {
                        TempData["ErrorMessage"] = result.errorid;
                        return RedirectToAction("Inicio");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Ocurrio un error, intentelo de nuevo";

                    return RedirectToAction("Inicio");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return RedirectToAction("Inicio", new { Mensaje = "Ocurrio un error", ActionErrorId = 3 });
            }
        }
        public ResponsePlanLealtadModel SendFormPlanLealtd(PlanesLealtadModel requestApi)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["getOrbisBalanceLoyalty"];
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Accept = "application/json";

                requestApi.key = ConfigurationManager.AppSettings["KEY_ID"];

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(requestApi);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resultString = streamReader.ReadToEnd();

                    if (!string.IsNullOrEmpty(resultString))
                    {
                        var result = JsonConvert.DeserializeObject<ResponsePlanLealtadModel>(resultString);
                        return result;
                    }
                    else
                    {
                        return new ResponsePlanLealtadModel
                        {
                            historialapego = new List<historialapego>(),
                            bonuspending = new List<bonuspending>(),
                            errorid = 0,
                            message = "Respuesta vacía del servidor"
                        };
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }

    }
}