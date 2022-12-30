import { Select } from "antd";

interface Props {
  label: string;
  placeholder: string;
  options: {
    value: string;
    label: string;
  }[];
}

const SelectFilter = ({ label, placeholder, options }: Props) => {
  return (
    <div className="filter">
      <p className="header-font">{label}</p>
      <Select
        style={{ width: "200px" }}
        showSearch
        placeholder={placeholder}
        optionFilterProp="label"
        allowClear
        placement="bottomLeft"
        size="large"
        options={options}
      />
    </div>
  );
};

export default SelectFilter;
