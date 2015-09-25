using Domain.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public enum EBannerType
    {
        DEPARTAMENT = 1, SERVICE = 2, CARROUSEL = 3, MINI_CARROUSEL = 4, FOOTER = 5, TOP = 6
    }

    /// <summary>
    /// This class is responsable for show the promotions banners
    /// </summary>
    public class BannerEntity : Entity<int>
    {
        #region Properties
        public string ImagePath { get; private set; }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string TipText { get; private set; }
        public EBannerType Type { get; private set; }
        public string UrlNavigate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int Width { get; private set; }
        public int Heigth { get; private set; }
 

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="subtitle"></param>
        /// <param name="description"></param>
        /// <param name="imagePath"></param>
        public BannerEntity(EBannerType type, string title,  DateTime startDate, DateTime endDate)
        {
            this.SetBannerType(type);
            this.SetTitle(title);
            this.SetStartDate(startDate);
            this.SetEndDate(endDate);
        }

        /// <summary>
        /// Constructor used for reflection
        /// </summary>
        public BannerEntity() { }

        #endregion

        #region Set Methods

        /// <summary>
        /// Set the banner type
        /// </summary>
        /// <param name="type"></param>
        public void SetBannerType(EBannerType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Set id banner
        /// </summary>
        /// <param name="id"></param>
        public void SetId(int id)
        {
            if (id <= 0)
                throw new Exception(Messages.BannerIdInvalid);

            this.Id = id;
        }

        /// <summary>
        /// Set image path of banner
        /// </summary>
        /// <param name="imagePath"></param>
        public void SetImagePath(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                throw new Exception(Messages.BannerImagePathEmpty);

            this.ImagePath = imagePath;
        }

        /// <summary>
        /// Set title text
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception(Messages.BannerTitleEmpty);

            this.Title = title;
        }

        /// <summary>
        /// Set subtitle text
        /// </summary>
        /// <param name="subtitle"></param>
        public void SetSubtitle(string subtitle)
        {
            if (string.IsNullOrWhiteSpace(subtitle))
                throw new Exception(Messages.BannerSubtitleEmpty);

            this.Subtitle = subtitle;
        }

        /// <summary>
        /// Set tip text
        /// </summary>
        /// <param name="text"></param>
        public void SetTipText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new Exception(Messages.BannerSubtitleEmpty);

            this.TipText = text;
        }

        /// <summary>
        /// Set url destination
        /// </summary>
        /// <param name="url"></param>
        public void SetUrlNavigate(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new Exception(Messages.BannerSubtitleEmpty);

            this.UrlNavigate = url;
        }

        /// <summary>
        /// Set banner description
        /// </summary>
        /// <param name="description"></param>
        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new Exception(Messages.BannerDescriptioEmpty);

            this.Description = description;
        }

        /// <summary>
        /// Start date show banner
        /// </summary>
        /// <param name="startDate"></param>
        public void SetStartDate(DateTime startDate)
        {
            this.StartDate = startDate;
        }

        /// <summary>
        /// End date show banner
        /// </summary>
        /// <param name="endDate"></param>
        public void SetEndDate(DateTime endDate)
        {
            this.EndDate = endDate;
        }

        /// <summary>
        /// Configura a largura do banner
        /// </summary>
        /// <param name="width"></param>
        public void SetWidth(int width)
        {
            this.Width = width;
        }

        /// <summary>
        /// Configura a altura do banner
        /// </summary>
        /// <param name="heigth"></param>
        public void SetHeigth(int heigth)
        {
            this.Heigth = heigth;
        }
        #endregion
    }
}


