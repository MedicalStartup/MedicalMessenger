namespace DataLayer.MedicalDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medical_Assessments
    {
        [Key]
        public int assesment_id { get; set; }

        public Guid doctor_id { get; set; }

        public int sum_raitings { get; set; }

        public int count_of_votes { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? rating { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
