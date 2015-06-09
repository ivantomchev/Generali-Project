namespace Project.Web.ViewModels.NavigationItems
{
    using System.Collections.Generic;

    using AutoMapper;

    using Project.Data.Models;
    using Project.Web.Infrastructure.Mapping;

    public class NavigationItemViewModel : IMapFrom<NavigationItem>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int? ParentItemId { get; set; }

        public IEnumerable<NavigationItem> Children { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<NavigationItem, NavigationItemViewModel>()
                .ForMember(d => d.ParentItemId, opt => opt.MapFrom(s => s.ParentNavigationItem.Id));
        }
    }
}