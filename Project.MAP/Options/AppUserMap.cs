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

            Property(x => x.UserName).HasColumnName("Kullanıcı İsmi").IsRequired();
            Property(x => x.Password).HasColumnName("Şifre").IsRequired();
            Property(x => x.Email).HasColumnName("Mail Adresi").IsRequired();
            Property(x => x.Role).HasColumnName("Kullanıcı Rolü");
            Property(x => x.IsActive).HasColumnName("Aktif");
            Property(x => x.ActivationCode).HasColumnName("Aktivasyon Kodu");
            Property(x => x.IsBanned).HasColumnName("Yasaklı");
            Property(x => x.Point).HasColumnName("Puan");

        }
    }
}
