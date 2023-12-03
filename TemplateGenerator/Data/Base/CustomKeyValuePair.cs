using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateGenerator.Data.Base
{
    public class CustomKeyValuePair<K,V> : BaseDataModel
    {

        //  VARIABLES

        private K? _key;
        private V? _value;


        //  GETTERS & SETTERS

        public K? Key
        {
            get => _key;
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        public V? Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> CustomKeyValuePair class constructor. </summary>
        public CustomKeyValuePair()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> CustomKeyValuePair class constructor. </summary>
        /// <param name="key"> Key. </param>
        public CustomKeyValuePair(K key)
        {
            Key = key;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> CustomKeyValuePair class constructor. </summary>
        /// <param name="key"> Key. </param>
        /// <param name="value"> Value. </param>
        public CustomKeyValuePair(K key, V value)
        {
            Key = key;
            Value = value;
        }

        #endregion CLASS METHODS

    }
}
