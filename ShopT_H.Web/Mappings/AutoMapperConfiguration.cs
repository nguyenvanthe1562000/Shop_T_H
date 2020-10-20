﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Shop_T_H.Model.Models;
using Shop_T_H.Web.Models;

namespace Shop_T_H.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void  Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<PostTag, PostTagViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();

        }
    }
}