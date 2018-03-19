using Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class EntityDefinitionsController : Controller
    {
        private WebEAVContext db;

        public EntityDefinitionsController(WebEAVContext context)
        {
            db = context;
        }
        
        // GET: EntityDefinitions
        public ActionResult Index()
        {
            return View(db.EntityDefinitions.ToList());
        }

        // GET: EntityDefinitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityDefinition EntityDefinition = db.EntityDefinitions.Find(id);
            if (EntityDefinition == null)
            {
                return HttpNotFound();
            }
            return View(EntityDefinition);
        }

        // GET: EntityDefinitions/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.EntityDefinitions = await db.EntityDefinitions.AllAsync(g => true);

            return View();
        }

        // POST: EntityDefinitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntityDefinitionId,Name")] EntityDefinition EntityDefinition)
        {
            if (ModelState.IsValid)
            {
                db.EntityDefinitions.Add(EntityDefinition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(EntityDefinition);
        }

        // GET: EntityDefinitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityDefinition EntityDefinition = db.EntityDefinitions.Find(id);
            if (EntityDefinition == null)
            {
                return HttpNotFound();
            }
            return View(EntityDefinition);
        }

        // POST: EntityDefinitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntityDefinitionId,Name")] EntityDefinition entityDefinition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entityDefinition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entityDefinition);
        }

        // GET: EntityDefinitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityDefinition EntityDefinition = db.EntityDefinitions.Find(id);
            if (EntityDefinition == null)
            {
                return HttpNotFound();
            }
            return View(EntityDefinition);
        }

        // POST: EntityDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntityDefinition entityDefinition = db.EntityDefinitions.Find(id);
            db.EntityDefinitions.Remove(entityDefinition);
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
