using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite.Adm.Facade;
using Domain;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Adapters;

namespace WebSite.Adm.Tests
{
    [TestClass]
    public class BannerFacadeTests
    {
        private Moq.Mock<IBannerRepository> _bannerRepositoryMoq = null;
        private Moq.Mock<ITypeAdapter> _adapterMoq = null;
        private Moq.Mock<IUnitOfWork> _uowMoq = null;

        [TestInitialize]
        public void InitializeTests()
        {
            _bannerRepositoryMoq = new Moq.Mock<IBannerRepository>();
            _uowMoq = new Moq.Mock<IUnitOfWork>();
            _adapterMoq = new Moq.Mock<ITypeAdapter>();
        }


        [TestMethod]
        public void BannerGetAllTest()
        {
            //Configurando o mock da lista
            IList<BannerEntity> list = new List<BannerEntity>() { 
                    new BannerEntity(EBannerType.DEPARTAMENT, "teste",   DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+10)) };

            IQueryable<BannerEntity> queryResult = list.AsQueryable();
            _bannerRepositoryMoq.Setup(a => a.Query(c => c.Id > 0)).Returns(queryResult);

            IBannerFacade bannerFacade = new BannerFacade(_uowMoq.Object, _bannerRepositoryMoq.Object, _adapterMoq.Object);

            var bannerResults = bannerFacade.GetAll(0, 10);
            Assert.IsNotNull(bannerResults);
        }
    }
}
