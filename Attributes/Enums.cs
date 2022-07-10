using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picorm.Enums
{
    public enum FieldDirection
    {
        /// <summary>
        ///Value should be ignored.
        /// </summary>
        Ignore = 0,

        /// <summary>
        ///Value intended to be readed from the database. 
        ///Mapped property should be writable. 
        ///Mapped field should be public. 
        /// </summary>
        Read = 1,

        /// <summary>
        ///Value intended to be writed to the database. 
        ///Mapped property should be readable. 
        ///Mapped field should be public. 
        /// </summary>
        Write = 2,

        /// <summary>
        ///Value intended to be writed to and readed from the database. 
        ///Mapped property should be both readable and writable. 
        ///Mapped field should be public. 
        /// </summary>
        ReadWrite = 3,

        /// <summary>
        ///Value intended to be used as a filter parameter on queries.
        ///Mapped property should be readable. 
        ///Mapped field should be public. 
        /// </summary>
        Filter = 4,
        Key = 5
    }
}