﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apis.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TouchSecurity")]
	public partial class VistasDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    #endregion
		
		public VistasDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TouchSecurityConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public VistasDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VistasDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VistasDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public VistasDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<EmpresasMasReportes> EmpresasMasReportes
		{
			get
			{
				return this.GetTable<EmpresasMasReportes>();
			}
		}
		
		public System.Data.Linq.Table<NumeroEmpresas> NumeroEmpresas
		{
			get
			{
				return this.GetTable<NumeroEmpresas>();
			}
		}
		
		public System.Data.Linq.Table<ReportesPorMes> ReportesPorMes
		{
			get
			{
				return this.GetTable<ReportesPorMes>();
			}
		}
		
		public System.Data.Linq.Table<ReportesUltimoMes> ReportesUltimoMes
		{
			get
			{
				return this.GetTable<ReportesUltimoMes>();
			}
		}
		
		public System.Data.Linq.Table<TotalReportes> TotalReportes
		{
			get
			{
				return this.GetTable<TotalReportes>();
			}
		}
		
		public System.Data.Linq.Table<UltimoReporte> UltimoReporte
		{
			get
			{
				return this.GetTable<UltimoReporte>();
			}
		}
		
		public System.Data.Linq.Table<ReportesPorCiudad> ReportesPorCiudad
		{
			get
			{
				return this.GetTable<ReportesPorCiudad>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EmpresasMasReportes")]
	public partial class EmpresasMasReportes
	{
		
		private string _Empresa_Nom;
		
		private System.Nullable<int> _Reportes;
		
		public EmpresasMasReportes()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Empresa_Nom", DbType="NVarChar(50)")]
		public string Empresa_Nom
		{
			get
			{
				return this._Empresa_Nom;
			}
			set
			{
				if ((this._Empresa_Nom != value))
				{
					this._Empresa_Nom = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reportes", DbType="Int")]
		public System.Nullable<int> Reportes
		{
			get
			{
				return this._Reportes;
			}
			set
			{
				if ((this._Reportes != value))
				{
					this._Reportes = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NumeroEmpresas")]
	public partial class NumeroEmpresas
	{
		
		private System.Nullable<int> _NUMERO_EMPRESAS;
		
		public NumeroEmpresas()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NUMERO_EMPRESAS", DbType="Int")]
		public System.Nullable<int> NUMERO_EMPRESAS
		{
			get
			{
				return this._NUMERO_EMPRESAS;
			}
			set
			{
				if ((this._NUMERO_EMPRESAS != value))
				{
					this._NUMERO_EMPRESAS = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ReportesPorMes")]
	public partial class ReportesPorMes
	{
		
		private string _Mes;
		
		private System.Nullable<int> _Reportes;
		
		public ReportesPorMes()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Mes", DbType="NVarChar(30)")]
		public string Mes
		{
			get
			{
				return this._Mes;
			}
			set
			{
				if ((this._Mes != value))
				{
					this._Mes = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reportes", DbType="Int")]
		public System.Nullable<int> Reportes
		{
			get
			{
				return this._Reportes;
			}
			set
			{
				if ((this._Reportes != value))
				{
					this._Reportes = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ReportesUltimoMes")]
	public partial class ReportesUltimoMes
	{
		
		private System.Nullable<int> _REPORTES;
		
		public ReportesUltimoMes()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_REPORTES", DbType="Int")]
		public System.Nullable<int> REPORTES
		{
			get
			{
				return this._REPORTES;
			}
			set
			{
				if ((this._REPORTES != value))
				{
					this._REPORTES = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TotalReportes")]
	public partial class TotalReportes
	{
		
		private System.Nullable<int> _TOTAL;
		
		public TotalReportes()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TOTAL", DbType="Int")]
		public System.Nullable<int> TOTAL
		{
			get
			{
				return this._TOTAL;
			}
			set
			{
				if ((this._TOTAL != value))
				{
					this._TOTAL = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UltimoReporte")]
	public partial class UltimoReporte
	{
		
		private int _Id;
		
		private System.Nullable<int> _Empresa_Per;
		
		private string _Descripcion;
		
		private System.Nullable<System.DateTime> _Fecha;
		
		public UltimoReporte()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Empresa_Per", DbType="Int")]
		public System.Nullable<int> Empresa_Per
		{
			get
			{
				return this._Empresa_Per;
			}
			set
			{
				if ((this._Empresa_Per != value))
				{
					this._Empresa_Per = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Descripcion", DbType="NVarChar(100)")]
		public string Descripcion
		{
			get
			{
				return this._Descripcion;
			}
			set
			{
				if ((this._Descripcion != value))
				{
					this._Descripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="DateTime")]
		public System.Nullable<System.DateTime> Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this._Fecha = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ReportesPorCiudad")]
	public partial class ReportesPorCiudad
	{
		
		private string _Empresa_Nom;
		
		private System.Nullable<int> _Reportes;
		
		public ReportesPorCiudad()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Empresa_Nom", DbType="NVarChar(50)")]
		public string Empresa_Nom
		{
			get
			{
				return this._Empresa_Nom;
			}
			set
			{
				if ((this._Empresa_Nom != value))
				{
					this._Empresa_Nom = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reportes", DbType="Int")]
		public System.Nullable<int> Reportes
		{
			get
			{
				return this._Reportes;
			}
			set
			{
				if ((this._Reportes != value))
				{
					this._Reportes = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
