using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class EntityAttributeMap:BaseMap<EntityAttribute>
    {
        public EntityAttributeMap()
        {
            ToTable("Varlık Özellikleri ");
            Property(x => x.AttributeName).HasColumnName("Özellik İsmi").IsRequired();
            Property(x => x.Description).HasColumnName("Açıklama").IsRequired();
        }
    }
}
