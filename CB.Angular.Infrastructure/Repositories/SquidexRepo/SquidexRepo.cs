﻿using CB.Angular.Infrastructure.Configuration;
using CB.Angular.Infrastructure.Repositories.SquidexRepo.Contracts;
using CB.Angular.Infrastructure.Repositories.SquidexRepo.Models;
using Microsoft.Extensions.Options;
using Squidex.ClientLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Angular.Infrastructure.Repositories.SquidexRepo
{
    public class SquidexRepo : ISquidexRepo
    {
        private readonly SquidexClient<BlogCategoryEntity, BlogCategoryData> _blogCategoriesClient;
        private readonly SquidexClient<BlogPostEntity, BlogPostData> _blogPostClient;
        private readonly SquidexClient<BlogPostTagEntity, BlogPostTagData> _blogPostTagClient;
        private readonly SquidexClient<GlobalConfigEntity, GlobalConfigData> _globalClient;
        private readonly SquidexClient<ProfileEntity, ProfileData> _profileClient;

        public SquidexRepo(IOptions<SquidexConfig> appOptions)
        {
            var options = appOptions.Value;

            var clientManager =
                new SquidexClientManager(
                    options.Url,
                    options.AppName,
                    options.ClientId,
                    options.ClientSecret);

            _blogCategoriesClient = clientManager.GetClient<BlogCategoryEntity, BlogCategoryData>("blog-categories");
            _blogPostClient = clientManager.GetClient<BlogPostEntity, BlogPostData>("blog-posts");
            _blogPostTagClient = clientManager.GetClient<BlogPostTagEntity, BlogPostTagData>("blog-post-tags");
            _globalClient = clientManager.GetClient<GlobalConfigEntity, GlobalConfigData>("global");
            _profileClient = clientManager.GetClient<ProfileEntity, ProfileData>("profile");
        }

        public async Task<List<BlogCategoryEntity>> GetBlogCategories(int page = 0, int pageSize = 3)
        {
            var data = await _blogCategoriesClient.GetAsync(page * pageSize, pageSize);
            return data.Items;
        }

        public async Task<List<BlogPostEntity>> GetBlogPosts(int page = 0, int pageSize = 3)
        {
            var data = await _blogPostClient.GetAsync(page * pageSize, pageSize);
            return data.Items;
        }

        public async Task<List<BlogPostTagEntity>> GetBlogPostTags(int page = 0, int pageSize = 3)
        {
            var data = await _blogPostTagClient.GetAsync(page * pageSize, pageSize);
            return data.Items;
        }

        public async Task<GlobalConfigEntity> GetGlobalConfig()
        {
            var data = await _globalClient.GetAsync();
            return data.Items.FirstOrDefault();
        }

        public async Task<ProfileEntity> GetProfile()
        {
            var data = await _profileClient.GetAsync();
            return data.Items.FirstOrDefault();
        }
    }
}
