using Domain;
using Effort;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Tests
{
    [TestFixture]
    public class BookRepositoryTests
    {
        private WebSiteContext _context;
        private IBannerRepository _repository;

        [SetUp]
        public void Initialize()
        {
            var connection = DbConnectionFactory.CreateTransient() as System.Data.Common.DbConnection;
            _context = new WebSiteContext(connection);
            IUnitOfWork _uow = new UnitOfWork<WebSiteContext>(_context);
            _repository = new BannerRepository(_uow);
        }

        [Test]
        public void GetBook_WithNonExistingId_ReturnsNull()
        {


            BannerEntity banner = new BannerEntity(EBannerType.DEPARTAMENT, "Açougue", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(+30));
            banner.SetSubtitle("Carnes fresquinhas");
            banner.SetDescription("Carnes fresquinhas");
            banner.SetTipText("Açougue");
            banner.SetUrlNavigate("/");

            _context.Banners.Add(banner);
            _context.SaveChanges();
            var ok = _context.Banners.Where(a => a.Id > 0).FirstOrDefault();

            _repository.Add(banner);

            var ba = _repository.Query(a => a.Id > 0).ToList();

            Assert.IsTrue(banner.Id > 0);


            //// Arrange
            //const int nonExistingId = 155;

            //// Act
            //var book = _repository.Get(nonExistingId);

            //// Assert
            //book.Should().BeNull();
        }

        [Test]
        public void InsertBook_AddsBookToDatabase()
        {
            // Arrange
            //const string title = "To kill a mocking bird";
            //var book = new Book(title);

            //// Act
            //_repository.Insert(book);

            //// Assert
            //_context.Books.Should().HaveCount(1);
            //_context.Books.First().Should().NotBeNull();
            //_context.Books.First().Title.Should().Be(title);
        }

        [Test]
        public void GetBook_WithExistingId_ReturnsBook()
        {
            // Arrange
            //var book = new Book("To kill a mocking bird");
            //_repository.Insert(book);

            //// Act
            //var retrievedBook = _repository.Get(book.Id);

            //// Assert
            //book.Title.Should().Be(retrievedBook.Title);
            //book.Id.Should().Be(retrievedBook.Id);
        }
    }

}
