namespace Project.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NavigationItem
    {
        private ICollection<NavigationItem> children;

        public NavigationItem()
        {
            this.children = new HashSet<NavigationItem>();
        }

        [Index]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual NavigationItem ParentNavigationItem { get; set; }

        [InverseProperty("ParentNavigationItem")]
        public virtual ICollection<NavigationItem> Children
        {
            get
            {
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }

    }
}
