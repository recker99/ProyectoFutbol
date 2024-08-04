using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Equipo_Negocio
{
    public class Equipo : ObservableObject, IPersistente, INotifyPropertyChanged
    {
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public int EquipoId { get; set; }

        private string _nombreEquipo;
        private int _cantidadJugadores;
        private string _nombreDT;
        private string _tipoEquipo;
        private string _capitanEquipo;
        private bool _tieneSub21;

        public string NombreEquipo
        {
            get { return _nombreEquipo; }
            set
            {
                if (_nombreEquipo != value)
                {
                    _nombreEquipo = value;
                    OnPropertyChanged(nameof(NombreEquipo));
                }
            }
        }

        public int CantidadJugadores
        {
            get { return _cantidadJugadores; }
            set
            {
                if (_cantidadJugadores != value)
                {
                    _cantidadJugadores = value;
                    OnPropertyChanged(nameof(CantidadJugadores));
                }
            }
        }

        public string NombreDT
        {
            get { return _nombreDT; }
            set
            {
                if (_nombreDT != value)
                {
                    _nombreDT = value;
                    OnPropertyChanged(nameof(NombreDT));
                }
            }
        }

        public string TipoEquipo
        {
            get { return _tipoEquipo; }
            set
            {
                if (_tipoEquipo != value)
                {
                    _tipoEquipo = value;
                    OnPropertyChanged(nameof(TipoEquipo));
                }
            }
        }

        public string CapitanEquipo
        {
            get { return _capitanEquipo; }
            set
            {
                if (_capitanEquipo != value)
                {
                    _capitanEquipo = value;
                    OnPropertyChanged(nameof(CapitanEquipo));
                }
            }
        }

        public bool TieneSub21
        {
            get { return _tieneSub21; }
            set
            {
                if (_tieneSub21 != value)
                {
                    _tieneSub21 = value;
                    OnPropertyChanged(nameof(TieneSub21));
                }
            }
        }

        public string Error { get { return null; } }

        public string this[string name]
        {
            get
            {
                string res = null;

                switch (name)
                {
                    case nameof(NombreEquipo):
                        if (string.IsNullOrEmpty(NombreEquipo))
                            res = "El nombre del equipo es obligatorio";
                        break;
                    case nameof(CantidadJugadores):
                        if (CantidadJugadores <= 0)
                            res = "La cantidad de jugadores debe ser mayor a cero";
                        break;
                    case nameof(NombreDT):
                        if (string.IsNullOrEmpty(NombreDT))
                            res = "El nombre del director técnico es obligatorio";
                        break;
                    case nameof(TipoEquipo):
                        if (string.IsNullOrEmpty(TipoEquipo))
                            res = "El tipo de equipo es obligatorio";
                        break;
                    case nameof(CapitanEquipo):
                        if (string.IsNullOrEmpty(CapitanEquipo))
                            res = "El nombre del capitán es obligatorio";
                        break;
                }

                if (res == null)
                {
                    ErrorCollection.Remove(name);
                }
                else
                {
                    if (ErrorCollection.ContainsKey(name))
                        ErrorCollection[name] = res;
                    else
                        ErrorCollection.Add(name, res);
                }

                OnPropertyChanged(nameof(ErrorCollection));

                return res;
            }
        }

        public bool Create()
        {
            try
            {
                string encryptedNombreEquipo = AES.EncryptString(this.NombreEquipo);
                string encryptedNombreDT = AES.EncryptString(this.NombreDT);
                string encryptedTipoEquipo = AES.EncryptString(this.TipoEquipo);
                string encryptedCapitanEquipo = AES.EncryptString(this.CapitanEquipo);

                CommonBC.ModeloEquipo.spEquipoSave(
                    this.EquipoId,
                    encryptedNombreEquipo,
                    this.CantidadJugadores,
                    encryptedNombreDT,
                    encryptedTipoEquipo,
                    encryptedCapitanEquipo,
                    this.TieneSub21
                );
                CommonBC.ModeloEquipo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el equipo: " + ex.Message);
                return false;
            }
        }

        public bool Read(int equipoId)
        {
            try
            {
                var equipo = CommonBC.ModeloEquipo.Equipo.FirstOrDefault(e => e.EquipoId == equipoId);
                if (equipo != null)
                {
                    this.EquipoId = equipo.EquipoId;
                    this.NombreEquipo = AES.DecryptString(equipo.NombreEquipo);
                    this.CantidadJugadores = equipo.CantidadJugadores;
                    this.NombreDT = AES.DecryptString(equipo.NombreDT);
                    this.TipoEquipo = AES.DecryptString(equipo.TipoEquipo);
                    this.CapitanEquipo = AES.DecryptString(equipo.CapitanEquipo);
                    this.TieneSub21 = equipo.TieneSub21;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el equipo: " + ex.Message);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                string encryptedNombreEquipo = AES.EncryptString(this.NombreEquipo);
                string encryptedNombreDT = AES.EncryptString(this.NombreDT);
                string encryptedTipoEquipo = AES.EncryptString(this.TipoEquipo);
                string encryptedCapitanEquipo = AES.EncryptString(this.CapitanEquipo);

                CommonBC.ModeloEquipo.spEquipoUpdateById(
                    this.EquipoId,
                    encryptedNombreEquipo,
                    this.CantidadJugadores,
                    encryptedNombreDT,
                    encryptedTipoEquipo,
                    encryptedCapitanEquipo,
                    this.TieneSub21
                );
                CommonBC.ModeloEquipo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el equipo: " + ex.Message);
                return false;
            }
        }

        public bool Delete(int equipoId)
        {
            try
            {
                CommonBC.ModeloEquipo.spEquipoDeleteById(equipoId);
                CommonBC.ModeloEquipo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el equipo: " + ex.Message);
                return false;
            }
        }
    }
}
