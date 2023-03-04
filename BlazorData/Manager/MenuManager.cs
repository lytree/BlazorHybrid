using AutoMapper;
using BlazorConfiguration.Model.Dto;
using BlazorConfiguration.Model.Entity;
using BlazorConfiguration.Repository;
using FreeSql;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorConfiguration.Manager
{

	public class MenuManager
	{
		private MenuRepository _menuRepository;
		private IMapper _mapper;
		public MenuManager(MenuRepository menuRepository, IMapper mapper)
		{
			_menuRepository = menuRepository;
			_mapper = mapper;
		}

		public List<MenuDto> GetAllMenus()
		{

			return buildTree(_menuRepository.Select.ToList());
		}

		private List<MenuDto> buildTree(List<Menu> menus)
		{
			var tree = new List<MenuDto>();
			foreach (MenuDto treeRootNode in GetRootNode(menus))
			{
				// 完成一个顶级节点所构建的树形，增加进来
				tree.Add(buildChildTree(treeRootNode, menus));
			}

			return tree;
		}


		/*
		*   获取需构建的所有根节点（顶级节点） "0"
		*   @return 所有根节点List集合
		*/
		public List<MenuDto> GetRootNode(List<Menu> menus)
		{
			// 保存所有根节点（所有根节点的数据）
			List<MenuDto> rootNodeList = new();
			// treeNode：查询出的每一条数据（节点）
			foreach (Menu treeNode in menus)
			{
				// 判断当前节点是否为根节点，此处注意：若parentId类型是String，则要采用equals()方法判断。
				if (0 == treeNode.Parent)
				{
					// 是，添加
					var menuDto =_mapper.Map<MenuDto>(treeNode);
					rootNodeList.Add(menuDto);
				}
			}
			return rootNodeList;
		}
		/**
            *  递归-----构建子树形结构
            *  @param  pNode 根节点（顶级节点）
            *  @return 整棵树
            */
		public MenuDto buildChildTree(MenuDto pNode, List<Menu> menus)
		{
			List<MenuDto> childTree = new();
			// nodeList：所有节点集合（所有数据）
			foreach (Menu treeNode in menus)
			{
				// 判断当前节点的父节点ID是否等于根节点的ID，即当前节点为其下的子节点
				if (treeNode.Parent == pNode.Id)
				{
					// 再递归进行判断当前节点的情况，调用自身方法
					childTree.Add(buildChildTree(_mapper.Map<MenuDto>(treeNode), menus));
				}
			}
			// for循环结束，即节点下没有任何节点，树形构建结束，设置树结果
			if (childTree.Count > 0)
			{
				pNode.Children = childTree;
			}

			return pNode;
		}
	}
}
