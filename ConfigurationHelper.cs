namespace Vision.Common
{
    public static class ConfigurationHelper
    {

        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public static string PmcConnectionString
            => _configuration?.GetConnectionString(ConfigurationConstants.PMC_CONNECTION_STRING);

        public static string CommonDbConnectionString
          => _configuration?.GetConnectionString(ConfigurationConstants.COMMON_DB_CONNECTION_STRING);

        public static string BlobApiSubscriptionKey
            => _configuration?.GetSection(ConfigurationConstants.BLOB_API_SUB_KEY)?.Value;

        public static string BlobApiUrl
            => _configuration?.GetSection(ConfigurationConstants.BLOB_API_URL)?.Value;

        public static string BlobContainer
            => _configuration?.GetSection(ConfigurationConstants.BLOB_CONTAINER)?.Value;

        public static string RootFolderForEmployee
            => _configuration?.GetSection(ConfigurationConstants.BLOB_ROOT_FOLDER_EMPLOYEE)?.Value;

        public static int MaxFileSizeInMbs
                => int.Parse(_configuration?.GetSection(ConfigurationConstants.MAX_FILE_SIZE_IN_MBS)?.Value);

        public static int MaxTimelineEvents
                => int.Parse(GetValueFromConfig(ConfigurationConstants.MAX_TIMELINE_EVENTS, 3.ToString()));

        public static string TaskManagementApiUrl
            => _configuration?.GetSection(ConfigurationConstants.TASK_MANAGEMENT_API_URL)?.Value;

        public static int CacheKeyImpersonation
           => int.Parse(GetValueFromConfig(ConfigurationConstants.CACHING_IMPERSONATION_MINUTES, ConfigurationConstants.DEFAULT_CACHE_MINUTES));

        public static int CacheKeyUsersData
         => int.Parse(GetValueFromConfig(ConfigurationConstants.CACHING_USERSDATA_MINUTES, ConfigurationConstants.DEFAULT_CACHE_MINUTES));

        public static int CacheKeyCheckInUsersCount
        => int.Parse(GetValueFromConfig(ConfigurationConstants.CACHING_CHECKINUSERSCOUNT_MINUTES, ConfigurationConstants.DEFAULT_CACHE_USERCOUNT));

        public static int CacheKeyCaliforniaUsersData
         => int.Parse(GetValueFromConfig(ConfigurationConstants.CACHING_CALIFORNIAUSERS_MINUTES, ConfigurationConstants.DEFAULT_CACHE_MINUTES));

        public static string GoogleKey
            => _configuration?.GetSection(ConfigurationConstants.GOOGLE_KEY)?.Value;

        public static string BlobRootFolderContestItems
            => _configuration?.GetSection(ConfigurationConstants.BLOB_ROOT_FOLDER_CONTEST_ITEMS)?.Value;

        public static string StorageAccountKey
            => _configuration?.GetSection(ConfigurationConstants.Storage_AccountKey)?.Value;

        public static string StorageAccountName
            => _configuration?.GetSection(ConfigurationConstants.Storage_AccountName)?.Value;

        public static string StorageAccountUrl
            => _configuration?.GetSection(ConfigurationConstants.Storage_AccountUrl)?.Value;
        public static string DiscountCouponLimit
           => _configuration?.GetSection(ConfigurationConstants.DISCOUNTCOUPONLIMIT)?.Value;
        public static string RefundCouponLimit
           => _configuration?.GetSection(ConfigurationConstants.REFUNDCOUPONLIMIT)?.Value;
        public static string RefundPolicyCouponLimit
           => _configuration?.GetSection(ConfigurationConstants.REFUNDPOLICYCOUPONLIMIT)?.Value;

        private static string GetValueFromConfig(string key, string defaultValue)
        {

            if (_configuration?.GetSection(key).Value is null)
                return defaultValue;

            return _configuration.GetSection(key).Value;
        }
    }
}
