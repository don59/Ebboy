using System;

namespace Ebboy.Core.Caching
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// ��ȡ���棬������治���ڣ���ͨ��ָ��������ȡ�����û���60���ӡ�
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cacheManager">��������</param>
        /// <param name="key">�ؼ���</param>
        /// <param name="acquire">��ȡ�������ݵķ���</param>
        /// <returns></returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        /// <summary>
        /// ��ȡ���棬������治���ڣ���ͨ��ָ��������ȡ�����û��档
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cacheManager">��������</param>
        /// <param name="key">�ؼ���</param>
        /// <param name="cacheTime">����ʱ�䣨��λ���ӣ���0Ϊ�����档</param>
        /// <param name="acquire">��ȡ�������ݵķ���</param>
        /// <returns></returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire) 
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                if (cacheTime > 0)
                    cacheManager.Set(key, result, cacheTime);
                return result;
            }
        }

        /// <summary>
        /// ���»���
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheManager"></param>
        /// <param name="key"></param>
        /// <param name="cacheTime"></param>
        /// <param name="acquire"></param>
        /// <returns></returns>
        public static T Update<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheManager.IsSet(key))
            {
                cacheManager.Remove(key);
            }

            var result = acquire();
            if (cacheTime > 0)
                cacheManager.Set(key, result, cacheTime);
            return result;
        }
    }
}
