﻿using CB.Angular.Infrastructure.Repositories.SquidexRepo.Models;
using System.Collections.Generic;
using CB.Angular.Interface.CMS;

namespace CB.Angular.CMS.Mappers.Contracts
{
    public interface ICMSMapper
    {
        List<BlogCategory> MapToBlogCategories(List<BlogCategoryEntity> model);

        BlogCategory MapToBlogCategory(BlogCategoryEntity model);

        BlogPost MapToBlogPost(BlogPostEntity model, BlogCategoryEntity category, List<BlogPostTagEntity> tags);

        BlogPostTag MapToBlogPostTag(BlogPostTagEntity model);

        List<BlogPostTag> MapToBlogPostTags(List<BlogPostTagEntity> model);

        GlobalConfig MapToGlobalConfig(GlobalConfigEntity model);

        Profile MapToProfile(ProfileEntity model);
    }
}
