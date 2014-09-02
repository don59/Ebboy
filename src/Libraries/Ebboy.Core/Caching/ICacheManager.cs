namespace Ebboy.Core.Caching
{
    /// <summary>
    /// Cache manager interface
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// ��ȡ��������ָ���ļ��������ֵ��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// ���ָ���ļ��Ͷ���Ļ��棬����λ���ӡ�
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">����ʱ�䣬��λ����</param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// �ж��Ƿ��ѻ���ؼ���
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        bool IsSet(string key);

        /// <summary>
        /// �Ƴ�ָ������
        /// </summary>
        /// <param name="key">/key</param>
        void Remove(string key);

        /// <summary>
        ///  ���»���
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        void Update(string key, object data, int cacheTime);

        /// <summary>
        /// ͨ��������ʽɾ������
        /// </summary>
        /// <param name="pattern">pattern</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// ��ջ�������
        /// </summary>
        void Clear();
    }
}
