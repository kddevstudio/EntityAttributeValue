using Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Areas.Admin.ViewModels;

namespace Web.Areas.Admin.Controllers
{
    public class AttributesController : Controller
    {
        private WebEAVContext db;

        public AttributesController(WebEAVContext context)
        {
            db = context;
        }
        
        // GET: Attributes
        public async Task<ActionResult> Index()
        {
            var attributeListViewModel = new AttributeListViewModel();

            attributeListViewModel.ShowCommandLinks = true;
            attributeListViewModel.ShowDefinitionName = true;

            attributeListViewModel.Attributes = await db.Attributes.Include(f => f.EntityDefinition).ToListAsync();
            
            return View(attributeListViewModel);
        }

        // GET: Attributes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.EntityDefinitions = db.EntityDefinitions.Select(ed => new { ed.EntityDefinitionId, ed.Name}).ToList();
            Attribute Attribute = db.Attributes.Find(id);

            if (Attribute == null)
            {
                return HttpNotFound();
            }
            return View(Attribute);
        }

        // GET: Attributes/Create
        public ActionResult Create()
        {
            ViewData.Add("EntityDefinitions", db.EntityDefinitions.ToList());
            
            return View();
        }

        // POST: Attributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttributeId,Name,DataType,EntityDefinitionId")] Attribute attribute)
        {
            if (ModelState.IsValid)
            {
                db.Attributes.Add(attribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attribute);
        }

        // GET: Attributes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attribute attribute = db.Attributes.Find(id);
            if (attribute == null)
            {
                return HttpNotFound();
            }
            return View(attribute);
        }

        // POST: Attributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttributeId,Name,DataType")] Attribute Attribute)
        {
            if (ModelState.IsValid)
            {
                var attribute = db.Attributes.Find(Attribute.AttributeId);

                if (attribute == null)
                {
                    return HttpNotFound();
                }

                attribute.DataType = Attribute.DataType;
                attribute.Name = Attribute.Name;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(Attribute);
        }

        // GET: Attributes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attribute Attribute = db.Attributes.Find(id);
            if (Attribute == null)
            {
                return HttpNotFound();
            }
            return View(Attribute);
        }

        // POST: Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attribute Attribute = db.Attributes.Find(id);
            db.Attributes.Remove(Attribute);
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
