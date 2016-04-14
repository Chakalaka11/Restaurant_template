using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.Models
{
    public abstract class Items
    {
        public menu inner_item;
        public string name;
        public string getName()
        {
            return name;
        }
        public virtual void Add(Items CM)
        { }
        public virtual void Remove(Items CM)
        { }
        public virtual Items Get(string name)
        { return null; }
        
    }
    public class Item_category : Items
    {
       
        public Item_category(menu Temp)
        {
            inner_item = Temp;
            name = inner_item.Name;
        }
    }
    public class Category : Items
    {
       public List<Items> Category_list;
       
        public Category(menu Temp)
        {
            Category_list = new List<Items>();
            inner_item = Temp;
            name = inner_item.Name;
        }

        public Category(string Temp)
        {
            Category_list = new List<Items>();
            name = Temp;
        }

        public override void Add(Items CM)
        {
            Category_list.Add(CM);
        }
        public override void Remove(Items CM)
        {
            Category_list.Remove(CM);
        }
        public override Items Get(string name)
        {
            return Category_list.Find(x => x.name == name);
        }
        public int Count()
        {
            return Category_list.Count;
        }
    }
}