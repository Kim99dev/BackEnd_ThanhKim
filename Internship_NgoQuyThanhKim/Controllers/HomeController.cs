using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Internship_NgoQuyThanhKim.Models;

namespace Internship_NgoQuyThanhKim.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var monhoc = LaydsMonHoc();
            return View(monhoc);
        }
        // Tạo đối tượng chứa CSDL từ dbWeb
        dbWebDataContext db = new dbWebDataContext();

        // Lấy danh sách môn học
        private List<MonHoc> LaydsMonHoc()
        {
            return db.MonHocs.ToList();
        }
        // Lấy danh sách khóa học
        public ActionResult LaydsKhoaHoc()
        {
            var khoahoc = from kh in db.KhoaHocs select kh;
            return PartialView(khoahoc);
        }
        // Lấy danh sách môn học theo khóa
        public ActionResult MonHoctheoKhoa(int id)
        {
            var monhoc = from mh in db.MonHocs where mh.KhoaHocID == id select mh;
            var tenkh = from kh in db.KhoaHocs where kh.ID == id select kh;
            Session["KhoaHoc"] = tenkh.FirstOrDefault().TenKhoaHoc;
            return View(monhoc);
        }
    }
}