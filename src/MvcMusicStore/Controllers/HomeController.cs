﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Model;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicStoreEntities _storeDb = new MusicStoreEntities();

        public ActionResult Index()
        {
            // Get most popular albums
            List<Album> albums = GetTopSellingAlbums(5);

            return View(albums);
        }

        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            return _storeDb.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }
    }
}