using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using webbanxe.Areas.Admin.Models;
using webbanxe.Help;
using webbanxe.Models;
namespace webbanxe.Data

{
    public class InitalData

    {
        public static void Seed( IApplicationBuilder applicationBuilder)
        {
           
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope() )
            {
                var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
                
                if (!dataContext.AdminMenus.Any())
                {
                    dataContext.AdminMenus.AddRange(
                    new AdminMenu()
                    {
                        ItemName="Bảng điều khiển",
                        ItemLevel=0,
                        ParentLevel=0,
                        ItemOrder=1,
                        IsActive=true,
                        ItemTarget=null,
                        AreaName= "Admin",
                        ControllerName="Home",
                        ActionName="Index",
                        Icon=null,
                        IdName=null
                    }
                    );
                    dataContext.SaveChanges();

                }
                if (!dataContext.TypeBike.Any())
                {
                    dataContext.TypeBike.AddRange(
                        new TypeBike()
                        {
                            NameType = "Xe máy"
                        },
                         new TypeBike()
                         {
                             NameType = "Xe điện"
                         },
                          new TypeBike()
                          {
                              NameType = "Xe tay ga"
                          },
                           new TypeBike()
                           {
                               NameType  = "Xe thể thao"
                           }
                       );
                    dataContext.SaveChanges() ;
                }

                if (!dataContext.Bike.Any())
                {
                    dataContext.Bike.AddRange(
                        new Bike()
                        {
                            NameBike="Xe Sirius",
                            IdType=1,
                            price=12000000,
                            PricePromotion=0.5,
                            Quantity=5,
                            DescriptionBike="Xe máy sirues > 50cc",
                            ImageBike="Anh1.jpg" ,
                            
                        },
                         new Bike()
                         {
                             NameBike = "Xe Đạp điện",
                             IdType = 2,
                             price = 7000000,
                             PricePromotion = 0.5,
                             Quantity = 5,
                             DescriptionBike = "Xe máy điện < 50cc",
                             ImageBike = "Anh1.jpg"
                         }
                       );
                    dataContext.SaveChanges();
                }
                if (!dataContext.Roles.Any())
                {
                    dataContext.Roles.AddRange(
                    new Roles()
                    {
                       
                        RoleName = "Admin"
                    },
                    new Roles()
                    {
                        
                        RoleName = "User"
                    });
                    dataContext.SaveChanges();
                }
                if ( !dataContext.Users.Any() ) {
                    dataContext.Users.AddRange(
                        new User()
                        {
                            RoleId = 1,
                            UserName="admin",
                            Password=EncryptPassword.EncrytMd5("admin"),
                            DisplayName="admin",
                            Phone="0665685",
                        },
                        new User()
                        {
                            RoleId = 2,
                            UserName = "dangnam",
                            Password = EncryptPassword.EncrytMd5("dangnam"),
                            DisplayName = "dangnam",
                            Phone = "0665685",
                        }
                        ); 
                    };
                dataContext.SaveChanges();
            }

            
        }
    }
}
