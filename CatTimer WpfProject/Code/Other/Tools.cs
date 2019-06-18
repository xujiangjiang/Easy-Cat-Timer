using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatTimer_WpfProject
{
    /// <summary>
    /// 所有的工具
    /// </summary>
    public static class Tools
    {
        #region 限制

        /// <summary>
        /// 把1个数字限制在一个范围内
        /// （和Unity的Mathf.Clamp()用法一样）
        /// </summary>
        /// <param name="value">要限制的值</param>
        /// <param name="min">最小值（如果数字小于最小值，就让数字等于最小值）</param>
        /// <param name="max">最大值（如果数字大于最大值，就让数字等于最大值）</param>
        /// <returns>返回：限制之后的值</returns>
        public static int Clamp(int value, int min, int max)
        {
            //如果数字小于最小值，就让数字等于最小值
            if (value < min)
            {
                value = min;
            }

            //如果数字大于最大值，就让数字等于最大值
            else if (value > max)
            {
                value = max;
            }


            return value;
        }


        /// <summary>
        /// 把1个数字限制在一个范围内
        /// （和Unity的Mathf.Clamp()用法一样）
        /// </summary>
        /// <param name="value">要限制的值</param>
        /// <param name="min">最小值（如果数字小于最小值，就让数字等于最小值）</param>
        /// <param name="max">最大值（如果数字大于最大值，就让数字等于最大值）</param>
        /// <returns>返回：限制之后的值</returns>
        public static double Clamp(double value, double min, double max)
        {
            //如果数字小于最小值，就让数字等于最小值
            if (value < min)
            {
                value = min;
            }

            //如果数字大于最大值，就让数字等于最大值
            else if (value > max)
            {
                value = max;
            }


            return value;
        }

        #endregion




        #region 生成随机数

        private static Random random = new Random();//随机数组件，用于生成随机数

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min">最小的数</param>
        /// <param name="max">最大的数（不包含这个数）</param>
        /// <returns></returns>
        public static int GetRandom(int min, int max)
        {
            return random.Next(min, max);
        }

        #endregion
    }
}
