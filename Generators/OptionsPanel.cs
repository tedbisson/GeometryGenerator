﻿using GeometryGenerator.Geometry;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace GeometryGenerator.Generators
{
    public class OptionsPanel
    {
        public class Descriptor
        {
            public string Name;
            public float DefaultValue;
            public float MinValue;
            public float MaxValue;
            public bool IsFloat;
            public float Increment;

            public Descriptor(
                string name,
                float defaultValue,
                float minValue,
                float maxValue,
                bool isFloat,
                float increment)
            {
                Name = name;
                DefaultValue = defaultValue;
                MinValue = minValue;
                MaxValue = maxValue;
                IsFloat = isFloat;
                Increment = increment;
            }
        }

        // Establish consistent sizes for common content.
        private const int PANEL_WIDTH = 241;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_HEIGHT = 31;
        private const int COMBOBOX_HEIGHT = 33;

        // The panel containing the options controls.
        private Panel m_panel;
        private Dictionary<NumericUpDown, Descriptor> m_map = new Dictionary<NumericUpDown, Descriptor>();

        /// <summary>
        /// Constructor, creates an empty panel.
        /// </summary>
        public OptionsPanel()
        {
            m_panel = new Panel();
            m_panel.Size = new Size(1, 1);
        }

        public void CreateFromDescriptors(
            Descriptor[] descriptors)
        {
            int labelX = 5;
            int labelWidth = 130;
            int textBoxX = labelX + labelWidth + 5;
            int textBoxWidth = PANEL_WIDTH - textBoxX - 5;
            int y = 5;

            foreach (Descriptor descriptor in descriptors)
            {
                Label label = new Label();
                label.Text = descriptor.Name;
                label.TextAlign = ContentAlignment.TopRight;
                label.Location = new Point(labelX, y);
                label.Size = new Size(labelWidth, LABEL_HEIGHT);
                m_panel.Controls.Add(label);

                NumericUpDown textBox = new NumericUpDown();
                textBox.Text = descriptor.DefaultValue.ToString();
                textBox.Location = new Point(textBoxX, y);
                textBox.Size = new Size(textBoxWidth, TEXTBOX_HEIGHT);
                textBox.TextChanged += OnTextChanged;
                if (descriptor.IsFloat == true)
                    textBox.DecimalPlaces = 2;
                textBox.Minimum = (decimal)descriptor.MinValue;
                textBox.Maximum = (decimal)descriptor.MaxValue;
                textBox.Increment = (decimal)descriptor.Increment;
                m_panel.Controls.Add(textBox);

                m_map.Add(textBox, descriptor);

                y += 38;
            }

            m_panel.Size = new Size(PANEL_WIDTH, y);
        }

        public Panel GetOptionsPanel()
        {
            return m_panel;
        }

        public Dictionary<string, float> GetValues()
        {
            Dictionary<string, float> values = new Dictionary<string, float>();

            foreach (var item in m_map)
            {
                float v = 0.0f;
                if (float.TryParse(item.Key.Text, out v) == true)
                {
                    values.Add(item.Value.Name, v);
                }
            }

            return values;
        }

        private void OnTextChanged(object? sender, EventArgs e)
        {
            NumericUpDown? textBox = sender as NumericUpDown;
            if (textBox != null && m_map.ContainsKey(textBox) == true)
            {
                Descriptor descriptor = m_map[textBox];

                float value = 0.0f;
                if (float.TryParse(textBox.Text, out value) == true)
                {
                    if (value >= descriptor.MinValue && value <= descriptor.MaxValue)
                    {
                        GeometryForm.MainForm?.RebuildModel();
                    }
                }
            }
        }
    }
}
