using PhoneBook.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class DepartmantsController : Controller
    {
        private Entities db = new Entities();

        // GET: Departmants
        public ActionResult Index()
        {
            var departmant = db.Departmants;
            return View(departmant.ToList());
        }

        // GET: Departmants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var departmant = db.Departmants.Find(id);
            if (departmant == null)
            {
                return HttpNotFound();
            }
            return View(departmant);
        }

        // GET: Departmants/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Departmants, "ID", "Name");
            ViewBag.ID = new SelectList(db.Departmants, "ID", "Name");
            return View();
        }

        // POST: Departmants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Departmant departmant)
        {
            if (ModelState.IsValid)
            {
                db.Departmants.Add(departmant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Departmants, "ID", "Name", departmant.ID);
            ViewBag.ID = new SelectList(db.Departmants, "ID", "Name", departmant.ID);
            return View(departmant);
        }

        // GET: Departmants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departmant departmant = db.Departmants.Find(id);
            if (departmant == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Departmants, "ID", "Name", departmant.ID);
            ViewBag.ID = new SelectList(db.Departmants, "ID", "Name", departmant.ID);
            return View(departmant);
        }

        // POST: Departmants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Departmant departmant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Departmants, "ID", "Name", departmant.ID);
            ViewBag.ID = new SelectList(db.Departmants, "ID", "Name", departmant.ID);
            return View(departmant);
        }

        // GET: Departmants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departmant departmants = db.Departmants.Find(id);
            if (departmants == null)
            {
                return HttpNotFound();
            }
            return View(departmants);
        }

        // POST: Departmants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departmant departmant = db.Departmants.Find(id);
            db.Departmants.Remove(departmant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
