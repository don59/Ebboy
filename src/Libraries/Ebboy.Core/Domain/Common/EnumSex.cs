﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Domain.Common
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum EnumSex
    {
        /// <summary>
        /// 女
        /// </summary>
        [Description("女")]
        Female = 0,
        /// <summary>
        /// 男
        /// </summary>
        [Description("男")]
        Male =1
    }
}
