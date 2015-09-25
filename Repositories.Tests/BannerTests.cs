using Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
using System.Reflection;
using System.Data.Entity;
namespace Repositories.Tests
{
    [TestFixture]
    public class BannerTests
    {
        private IUnitOfWork _uow;
        private IBannerRepository _bannerRepo;

        [SetUp]
        public void Setup()
        {
            _uow = new UnitOfWork<WebSiteContext>();
            _bannerRepo = new BannerRepository(this._uow);
        }

        [Test]
        public void AddBannerTest()
        {

            BannerEntity banner = new BannerEntity(EBannerType.DEPARTAMENT, "Açougue", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner.SetSubtitle("Carnes fresquinhas");
            banner.SetDescription("Carnes fresquinhas");
            banner.SetTipText("Açougue");
            banner.SetUrlNavigate("/");

            _bannerRepo.Add(banner);

            BannerEntity banner2 = new BannerEntity(EBannerType.DEPARTAMENT, "Padaria",  DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner2.SetSubtitle("Pães fresquinhos");
            banner2.SetDescription("Carnes fresquinhas");
            banner2.SetTipText("Açougue");
            banner2.SetUrlNavigate("/");
            _bannerRepo.Add(banner2);

            BannerEntity banner3 = new BannerEntity(EBannerType.DEPARTAMENT, "Hortifruti",  DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner3.SetSubtitle("Frutas fresquinhas");
            banner3.SetDescription("Carnes fresquinhas");
            banner3.SetTipText("Frutas fresquinhas");
            banner3.SetTipText("Açougue");
            banner3.SetUrlNavigate("/");
            _bannerRepo.Add(banner3);

            BannerEntity banner4 = new BannerEntity(EBannerType.DEPARTAMENT, "Congelados",  DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner4.SetSubtitle("Melhores marcas");
            banner4.SetDescription("Melhores marcas");
            banner4.SetTipText("Açougue");
            banner4.SetTipText("Açougue");
            banner4.SetUrlNavigate("/");
            _bannerRepo.Add(banner4);



            BannerEntity banner5 = new BannerEntity(EBannerType.TOP, "Banner 1", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner5.SetSubtitle("Banner 1");
            banner5.SetDescription("Banner 1");
            banner5.SetTipText("Banner 1");
            banner5.SetTipText("Banner 1");
            banner5.SetUrlNavigate("/");
            banner5.SetHeigth(1600);
            banner5.SetHeigth(599);
            _bannerRepo.Add(banner5);


            BannerEntity banner6 = new BannerEntity(EBannerType.TOP, "Banner 2",  DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner6.SetSubtitle("Banner 2");
            banner6.SetDescription("Banner 2");
            banner6.SetTipText("Banner 2");
            banner6.SetTipText("Banner 2");
            banner6.SetUrlNavigate("/");
            banner6.SetHeigth(1600);
            banner6.SetHeigth(599);
            _bannerRepo.Add(banner6);


            BannerEntity banner7 = new BannerEntity(EBannerType.TOP, "Banner 3",DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner7.SetSubtitle("Banner 3");
            banner7.SetDescription("Banner 3");
            banner7.SetTipText("Banner 3");
            banner7.SetTipText("Banner 3");
            banner7.SetUrlNavigate("/");
            banner7.SetHeigth(1600);
            banner7.SetHeigth(599);
            _bannerRepo.Add(banner7);


            BannerEntity banner8 = new BannerEntity(EBannerType.TOP, "Banner 4", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner8.SetSubtitle("Banner 4");
            banner8.SetDescription("Banner 4");
            banner8.SetTipText("Banner 4");
            banner8.SetTipText("Banner 4");
            banner8.SetUrlNavigate("/");
            _bannerRepo.Add(banner8);


            BannerEntity banner9 = new BannerEntity(EBannerType.TOP, "Banner 5",  DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner9.SetSubtitle("Banner 5");
            banner9.SetDescription("Banner 5");
            banner9.SetTipText("Banner 5");
            banner9.SetTipText("Banner 5");
            banner9.SetUrlNavigate("/");
            banner9.SetHeigth(1600);
            banner9.SetHeigth(599);
            _bannerRepo.Add(banner9);


            BannerEntity banner10 = new BannerEntity(EBannerType.TOP, "Banner 6",  DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner10.SetSubtitle("Banner 6");
            banner10.SetDescription("Banner 6");
            banner10.SetTipText("Banner 6");
            banner10.SetTipText("Banner 6");
            banner10.SetUrlNavigate("/");
            banner10.SetHeigth(1600);
            banner10.SetHeigth(599);
            _bannerRepo.Add(banner10);



            this._uow.SaveChanges();
            Assert.IsTrue(banner.Id > 0);
        }

        [Test]
        public void FindByIdBannerTest()
        {

            BannerEntity banner10 = new BannerEntity(EBannerType.TOP, "Banner 6",DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner10.SetSubtitle("Banner 6");
            banner10.SetDescription("Banner 6");
            banner10.SetTipText("Banner 6");
            banner10.SetTipText("Banner 6");
            banner10.SetUrlNavigate("/");
            banner10.SetHeigth(1600);
            banner10.SetHeigth(599);
            _bannerRepo.Add(banner10);


            BannerEntity banner = _bannerRepo.Query(a => a.Id == 2).FirstOrDefault();
            Assert.IsNotNull(banner);
        }

        [Test]
        public void FilterBannerTest()
        {
            var result = _bannerRepo.Query(a => a.Description.Contains("qui")).ToList();
            Assert.IsTrue(result.Count > 0);
        }
    }
}
