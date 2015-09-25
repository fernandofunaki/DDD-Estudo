using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSite.Adm.Models
{
    public class BannerViewModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        [StringLength(50, ErrorMessage = "O nome deve ter no mínimo 3 caracters e no máximo 50", MinimumLength = 3)]
        [Display(Name = "Título")]
        [Required(ErrorMessage = "Informe o título do banner")]
        public string Title { get; set; }

        [StringLength(50, ErrorMessage = "O nome deve ter no mínimo 3 caracters e no máximo 50", MinimumLength = 3)]
        [Required(ErrorMessage = "Informe o subtítulo do banner")]
        [Display(Name = "Subtitulo")]
        public string Subtitle { get; set; }

        [StringLength(150, ErrorMessage = "O nome deve ter no mínimo 3 caracters e no máximo 50", MinimumLength = 3)]
        [Required(ErrorMessage = "Informe a descrição do banner")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [StringLength(50, ErrorMessage = "O nome deve ter no mínimo 3 caracters e no máximo 50", MinimumLength = 3)]
        [Required(ErrorMessage = "Informe a descrição para o tool tip do banner")]
        [Display(Name = "ToolTipText")]
        public string TipText { get; set; }

        [Required(ErrorMessage = "Informe o tipo do banner")]
        [Display(Name = "Tipo")]
        public int Type { get; set; }

        [Display(Name = "Endereço para direcionamento")]
        public string UrlNavigate { get; set; }

        [Required(ErrorMessage = "Informe a data inicial")]
        [Display(Name = "Inicial")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Informe a data final")]
        [Display(Name = "Fim")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Largura")]
        public int Width { get; set; }

        [Display(Name = "Altura")]
        public int Heigth { get; set; }
    }
}