using AntDesign.ProLayout;
using AutoMapper;
using BlazorConfiguration.Manager;

namespace BlazorShared.Data
{
	public class MenuService
	{
		private MenuManager _manager;
		private IMapper _mapper;
		public MenuService(MenuManager manager, IMapper mapper)
		{
			_mapper = mapper;
			_manager = manager;
		}


		public MenuDataItem[] GetMenus()
		{
			var menuDtos = _manager.GetAllMenus();
			var menu = _mapper.Map<List<MenuDataItem>>(menuDtos).ToArray();
			return menu;
		}
	}
}
