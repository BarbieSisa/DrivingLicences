using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Documents
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("IdCart")]
        
        public int IDCard { get; set; }
        [Required]
        public bool MedicalDocument { get; set; }
        [Required]
        public bool BRC { get; set; }
        [Required]
        public bool TheoryExam {get; set;}
        [Required]
        public bool PracticalExam { get; set; }

        public bool CheckDocuments (bool MedicalDocument, bool BRC, bool TheoryExam, bool PracticalExam)
        {
            bool checkdocument = false;
            if (MedicalDocument == true && BRC == true && TheoryExam == true && PracticalExam == true)
                return checkdocument == true;
            else
                return checkdocument == false;
        }
        private Documents()
        {

        }

        public Documents(int iDCard, bool medicalDocument, bool bRC, bool theoryExam, bool practicalExam)
        {
            IDCard = iDCard;
            MedicalDocument = medicalDocument;
            BRC = bRC;
            TheoryExam = theoryExam;
            PracticalExam = practicalExam;
        }
    }
}
