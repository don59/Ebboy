using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace Ebboy.Core.Caching
{
    /// <summary>
    /// Represents a manager for caching between HTTP requests (long term caching)
    /// </summary>
    public partial class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }
        
        /// <summary>
        /// ��ȡ��������ָ���ļ��������ֵ��
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        /// <summary>
        /// ���ָ���ļ��Ͷ���Ļ��棬����λ���ӡ�
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">����ʱ�䣬��λ����</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// �ж��Ƿ��ѻ���ؼ���
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public virtual bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        /// <summary>
        /// �Ƴ�ָ������
        /// </summary>
        /// <param name="key">/key</param>
        public virtual void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// ���»���
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        public virtual void Update(string key, object data, int cacheTime)
        {
            if (IsSet(key))
                Remove(key);
            Set(key, data, cacheTime);
        }

        /// <summary>
        /// ͨ��������ʽɾ������
        /// </summary>
        /// <param name="pattern">pattern</param>
        public virtual void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// C��ջ�������
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
    }
}