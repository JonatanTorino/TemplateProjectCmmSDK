using Microsoft.Dynamics.Commerce.Runtime.ComponentModel.DataAnnotations;
using Microsoft.Dynamics.Commerce.Runtime.DataModel;
using System.Runtime.Serialization;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace DevAxDefaultOrderType.CommerceRuntime.Entities
{
    public class TrnLGRetailFunctionalityProfile : CommerceEntity
    {
        #region Propiedades

        [Key]
        [DataMember]
        [Column(nameof(ProfileId))]
        public string ProfileId
        {
            get { return (string)this[nameof(ProfileId)]; }
            set { this[nameof(ProfileId)] = value; }
        }

        [DataMember]
        [Column(nameof(TrnLGIsQuotation))]
        public int TrnLGIsQuotation
        {
            get { return (int)this[nameof(TrnLGIsQuotation)]; }
            set { this[nameof(TrnLGIsQuotation)] = value; }
        }

        [DataMember]
        [Column(nameof(RECID))]
        public long RECID
        {
            get { return (long)this[nameof(RECID)]; }
            set { this[nameof(RECID)] = value; }
        }

        #endregion Propiedades

        public TrnLGRetailFunctionalityProfile() : base(TRNLGRETAILFUNCTIONALITYPROFILE)
        {
        }

        #region Constantes

        private const string TRNLGRETAILFUNCTIONALITYPROFILE = "TRNLGRETAILFUNCTIONALITYPROFILE";

        #endregion Constantes
    }
}