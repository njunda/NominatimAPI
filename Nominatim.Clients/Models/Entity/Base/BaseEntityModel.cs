
using System.ComponentModel.DataAnnotations;

namespace Nominatim.Clients.Models.Entity.Base
{
    public abstract class BaseEntityModel
    {
        [Key]
        public Guid Id { get; private  set; }

        /// <summary>
        /// Use this to set the Forgein keys. 
        /// </summary>
        /// <param name="id"></param>
        public virtual void SetForeignkey(Guid id)
        {
        }
    }
}
