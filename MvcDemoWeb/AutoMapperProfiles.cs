using AutoMapper;
using MvcDemoBusiness.Models;
using MvcDemoWeb.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDemoWeb
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TestRequest, GetStringRequest>().ReverseMap();
            #region 公共
            CreateMap<long, DateTime?>().ConvertUsing(new LongToNullableDateTimeConverter());
            #endregion
        }

        /// <summary>
        /// 长整形转换成可空时间类型
        /// </summary>
        public class LongToNullableDateTimeConverter : ITypeConverter<long, DateTime?>
        {
            public DateTime? Convert(long source, DateTime? destination, ResolutionContext context)
            {
                if (source == 0)
                {
                    return null;
                }
                else
                {
                    return new DateTime(source);
                }
            }
        }
    }
}
