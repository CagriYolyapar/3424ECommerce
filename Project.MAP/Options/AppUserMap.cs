using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserMap:BaseMap<AppUser>
    {
        //Turgut:Map'de Türkce'lestirme ayarları
        public AppUserMap()
        {
            ToTable("Kullanıcılar");

            HasOptional(x => x.AppUserDetail).WithRequired(x => x.AppUser);
        }
    }
}
