using Adapters;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Adm.Models;

namespace WebSite.Adm.Facade
{
    public interface IBannerFacade
    {
        IList<BannerViewModel> GetAll(int pageNumber, int limit);
        void Add(BannerViewModel banner);
        void Update(BannerViewModel banner);
        void Delete(int id);

        BannerViewModel GetById(int id);
    }

    public class BannerFacade : IBannerFacade
    {
        private IBannerRepository _bannerRepository;
        private ITypeAdapter _typeAdapter;
        private IUnitOfWork _uow;
        public BannerFacade(IUnitOfWork uow, IBannerRepository bannerRepository, ITypeAdapter typeAdapter)
        {
            _uow = uow;
            _bannerRepository = bannerRepository;
            _typeAdapter = typeAdapter;
        }
        public IList<BannerViewModel> GetAll(int pageNumber, int limit)
        {
            var results = _bannerRepository.Query(a => a.Id > 0).ToList();
            IList<BannerViewModel> resultMapped = _typeAdapter.Adapt<List<BannerEntity>, List<BannerViewModel>>(results);
            return resultMapped;
        }

        public BannerViewModel GetById(int id)
        {
            BannerViewModel result = null;
            var banner = _bannerRepository.FindById(id);
            if (banner != null)
                result = _typeAdapter.Adapt<BannerEntity, BannerViewModel>(banner);
            return result;
        }

        public void Add(BannerViewModel banner)
        {
            var newBanner = BannerConvert(banner);
            _bannerRepository.Add(newBanner);
            _uow.SaveChanges();
        }

        public void Update(BannerViewModel banner)
        {
            var newBanner = BannerConvert(banner);
            _bannerRepository.Update(newBanner);
            _uow.SaveChanges();
        }

        public void Delete(int id)
        {
            _bannerRepository.Delete(id);
            _uow.SaveChanges();
        }

        private BannerEntity BannerConvert(BannerViewModel banner)
        {
            var newBanner = _typeAdapter.Adapt<BannerViewModel, BannerEntity>(banner);
            return newBanner;
        }
    }
}