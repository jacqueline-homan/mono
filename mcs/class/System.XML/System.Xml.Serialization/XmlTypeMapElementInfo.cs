//
// XmlTypeMapElementInfo.cs: 
//
// Author:
//   Lluis Sanchez Gual (lluis@ximian.com)
//
// (C) 2002, 2003 Ximian, Inc.  http://www.ximian.com
//

using System;
using System.Xml.Schema;
using System.Collections;

namespace System.Xml.Serialization
{
	/// <summary>
	/// Summary description for XmlTypeMapElementInfo.
	/// </summary>
	internal class XmlTypeMapElementInfo
	{
		string _elementName;
		string _namespace = "";
		XmlSchemaForm _form;
		XmlTypeMapMember _member;
		string _choiceValue;
		bool _isNullable;
		int _nestingLevel;	// Only for array items
		XmlTypeMapping _mappedType;
		TypeData _type;
		bool _wrappedElement = true;

		public XmlTypeMapElementInfo (XmlTypeMapMember member, TypeData type)
		{
			_member = member;
			_type = type;
		}

		public TypeData TypeData
		{
			get { return _type; }
			set { _type = value; }
		}

		public string ChoiceValue
		{
			get { return _choiceValue; }
			set { _choiceValue = value; }
		}

		public string ElementName
		{
			get { return _elementName; }
			set { _elementName = value; }
		}

		public string Namespace
		{
			get { return _namespace; }
			set { _namespace = value; }
		}

		public string DataTypeNamespace
		{
			get 
			{ 
				if (_mappedType == null) return XmlSchema.Namespace;
				else return _mappedType.XmlTypeNamespace;
			}
		}

		public XmlSchemaForm Form 
		{
			get { return _form; }
			set { _form = value; }
		}

		public XmlTypeMapping MappedType
		{
			get { return _mappedType; }
			set { _mappedType = value; }
		}

		public bool IsNullable
		{
			get { return _isNullable; }
			set { _isNullable = value; }
		}

		internal bool IsPrimitive
		{
			get { return _mappedType == null; }
		}

		public XmlTypeMapMember Member
		{
			get { return _member; }
			set { _member = value; }
		}

		public int NestingLevel
		{
			get { return _nestingLevel; }
			set { _nestingLevel = value; }
		}

		public bool MultiReferenceType
		{
			get 
			{ 
				if (_mappedType != null) return _mappedType.MultiReferenceType;
				else return false;
			}
		}

		public bool WrappedElement
		{
			get { return _wrappedElement; }
			set { _wrappedElement = value; }
		}

		public bool IsTextElement
		{
			get { return ElementName == "<text>"; }
			set { ElementName = "<text>"; Namespace = string.Empty; }
		}

		public bool IsUnnamedAnyElement
		{
			get { return ElementName == string.Empty; }
			set { ElementName = string.Empty; Namespace = string.Empty; }
		}

		public override bool Equals (object other)
		{
			XmlTypeMapElementInfo oinfo = (XmlTypeMapElementInfo)other;
			if (_elementName != oinfo._elementName) return false;
			if (_type.XmlType != oinfo._type.XmlType) return false;
			if (_namespace != oinfo._namespace) return false;
			if (_form != oinfo._form) return false;
			if (_choiceValue != oinfo._choiceValue) return false;
			if (_type != oinfo._type) return false;
			if (_isNullable != oinfo._isNullable) return false;
			return true;
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}
	}

	class XmlTypeMapElementInfoList: ArrayList
	{
	}
}

