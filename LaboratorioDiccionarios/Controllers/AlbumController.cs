using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LaboratorioDiccionarios.Models;

namespace LaboratorioDiccionarios.Controllers
{
    public class AlbumController : Controller
    {
        List<Album> AlbumP = new List<Album>();
        List<Album2> AlbumN = new List<Album2>();
            // GET: Album
        public ActionResult Index()
        {
            return View(new List<Album>());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase PostedFile)
        {
            string filePath = string.Empty;
            if(PostedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(PostedFile.FileName);
                string extension = Path.GetExtension(PostedFile.FileName);
                PostedFile.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);
                foreach(string row in csvData.Split('\n'))
                {
                    if(!string.IsNullOrEmpty(row))
                    {
                        AlbumP.Add(new Album
                        {
                            Equipo = row.Split(',')[0],
                            Codigo = Convert.ToInt32(row.Split(',')[1])
                        });
                    }
                }

            }

            return View(AlbumP);
        }

        //Pasar lista a diccionario1

        public ActionResult Diccionario()
        {
            var res = new Dictionary<Album, Album>();
            foreach (Album item in AlbumP)
            {
                if (!res.ContainsKey(item))
                {
                    res.Add(item, new Album { Equipo = item.Equipo, Codigo = item.Codigo}); 
                }
            }

            return View(res);
        }

        public ActionResult Actualizar()
        {
            return View(new List<Album2>());
        }

        [HttpPost]

        public ActionResult Actualizar(HttpPostedFileBase album2)
        {
            string filePath2 = string.Empty;
            if (album2 != null)
            {
                string path2 = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }

                filePath2 = path2 + Path.GetFileName(album2.FileName);
                string extension2 = Path.GetExtension(album2.FileName);
                album2.SaveAs(filePath2);

                string csvData2 = System.IO.File.ReadAllText(filePath2);
                foreach (string row2 in csvData2.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row2))
                    {
                        AlbumN.Add(new Album2
                        {
                            Equipo2 = row2.Split(',')[0],
                            Codigo2 = Convert.ToInt32(row2.Split(',')[1])
                        });
                    }
                }

            }

            return View(AlbumN);
        }

        //Pasar lista a diccionario2

        public ActionResult Diccionario2(Album2 llave)
        {
            var res2 = new Dictionary<Album2, Album2>();
            foreach (Album2 item in AlbumN)
            {
                if (!res2.ContainsKey(item))
                {
                    res2.Add(item, new Album2 { Equipo2 = item.Equipo2, Codigo2 = item.Codigo2 });
                }
            }

            return View(res2[llave]);
        }

        public ActionResult Buscar()
        {
            return View();
        }


        #region intento busqueda
        /*
        public ActionResult Buscar2(HttpPostedFileBase album2)
        {
            string filePath2 = string.Empty;
            if (album2 != null)
            {
                string path2 = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }

                filePath2 = path2 + Path.GetFileName(album2.FileName);
                string extension2 = Path.GetExtension(album2.FileName);
                album2.SaveAs(filePath2);

                string csvData2 = System.IO.File.ReadAllText(filePath2);
                foreach (string row2 in csvData2.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row2))
                    {
                        AlbumN.Add(new Album2
                        {
                            Equipo2 = row2.Split(',')[0],
                            Codigo2 = Convert.ToInt32(row2.Split(',')[1])
                        });
                    }
                }

            }
            return View();
        }*/
        #endregion
    }
}