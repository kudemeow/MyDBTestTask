//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testTaskDB.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Worker
    {
        public int Id_Worker { get; set; }
        public int Id_Employee { get; set; }
        public int Id_Organization { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Organization Organization { get; set; }
    }
}