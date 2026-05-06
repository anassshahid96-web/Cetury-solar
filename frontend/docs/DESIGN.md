---
name: Sustainable Authority
colors:
  surface: '#f7f9fb'
  surface-dim: '#d8dadc'
  surface-bright: '#f7f9fb'
  surface-container-lowest: '#ffffff'
  surface-container-low: '#f2f4f6'
  surface-container: '#eceef0'
  surface-container-high: '#e6e8ea'
  surface-container-highest: '#e0e3e5'
  on-surface: '#191c1e'
  on-surface-variant: '#45464d'
  inverse-surface: '#2d3133'
  inverse-on-surface: '#eff1f3'
  outline: '#76777d'
  outline-variant: '#c6c6cd'
  surface-tint: '#565e74'
  primary: '#000000'
  on-primary: '#ffffff'
  primary-container: '#131b2e'
  on-primary-container: '#7c839b'
  inverse-primary: '#bec6e0'
  secondary: '#006c49'
  on-secondary: '#ffffff'
  secondary-container: '#6cf8bb'
  on-secondary-container: '#00714d'
  tertiary: '#000000'
  on-tertiary: '#ffffff'
  tertiary-container: '#0d1c2f'
  on-tertiary-container: '#76859b'
  error: '#ba1a1a'
  on-error: '#ffffff'
  error-container: '#ffdad6'
  on-error-container: '#93000a'
  primary-fixed: '#dae2fd'
  primary-fixed-dim: '#bec6e0'
  on-primary-fixed: '#131b2e'
  on-primary-fixed-variant: '#3f465c'
  secondary-fixed: '#6ffbbe'
  secondary-fixed-dim: '#4edea3'
  on-secondary-fixed: '#002113'
  on-secondary-fixed-variant: '#005236'
  tertiary-fixed: '#d5e3fd'
  tertiary-fixed-dim: '#b9c7e0'
  on-tertiary-fixed: '#0d1c2f'
  on-tertiary-fixed-variant: '#3a485c'
  background: '#f7f9fb'
  on-background: '#191c1e'
  surface-variant: '#e0e3e5'
typography:
  headline-xl:
    fontFamily: Inter
    fontSize: 48px
    fontWeight: '700'
    lineHeight: '1.1'
    letterSpacing: -0.02em
  headline-lg:
    fontFamily: Inter
    fontSize: 32px
    fontWeight: '600'
    lineHeight: '1.2'
    letterSpacing: -0.01em
  headline-md:
    fontFamily: Inter
    fontSize: 24px
    fontWeight: '600'
    lineHeight: '1.3'
  body-lg:
    fontFamily: Inter
    fontSize: 18px
    fontWeight: '400'
    lineHeight: '1.6'
  body-md:
    fontFamily: Inter
    fontSize: 16px
    fontWeight: '400'
    lineHeight: '1.5'
  label-md:
    fontFamily: Inter
    fontSize: 14px
    fontWeight: '600'
    lineHeight: '1'
    letterSpacing: 0.05em
rounded:
  sm: 0.125rem
  DEFAULT: 0.25rem
  md: 0.375rem
  lg: 0.5rem
  xl: 0.75rem
  full: 9999px
spacing:
  unit: 8px
  container-max-width: 1280px
  gutter: 24px
  margin: 32px
  stack-sm: 8px
  stack-md: 24px
  stack-lg: 48px
---

## Brand & Style

This design system is built on the pillars of **precision, reliability, and forward-thinking sustainability**. It moves away from the clichéd "leaf and sun" imagery of traditional green energy, instead favoring a high-tech, industrial-grade aesthetic that communicates professional mastery over solar technology.

The style is **Corporate / Modern**, characterized by a rigorous adherence to a grid, generous whitespace, and a high-contrast palette. While the core philosophy is flat, the design system utilizes "energy gradients"—extremely subtle linear transitions in the primary and accent colors—to prevent the UI from feeling static and to evoke the movement of electricity. The overall emotional response should be one of absolute trust, as if the user is interacting with a high-end financial or aerospace platform.

## Colors

The palette is anchored by **Deep Navy Blue**, providing a foundation of stability and institutional authority. This is contrasted against **Energy Green**, a vibrant, high-visibility hue used sparingly for calls to action, status indicators, and data points representing power generation.

**Slate White** serves as the primary surface color, creating a clean, airy environment that enhances readability. For semantic states, use a monochromatic range of slates to maintain the professional tone. Gradients should be used only on large primary surfaces or primary buttons, moving from the base color to a slightly lighter tint (10% shift) at a 135-degree angle to simulate light hitting a solar panel.

## Typography

The design system utilizes **Inter** exclusively to leverage its systematic, utilitarian nature. The typeface is chosen for its exceptional legibility in data-heavy contexts, such as energy production tables and performance metrics.

Headlines should be set with tight letter-spacing and bold weights to project authority. Body text maintains a generous line height to ensure clarity and a sense of "breathability." Labels and small captions use a slightly increased letter-spacing and a semi-bold weight to ensure they remain distinct and readable even at small scales. Consistent use of weight over color for hierarchy is a key principle of this system.

## Layout & Spacing

This design system follows a **fixed grid model** for desktop environments to maintain a sense of structured, architectural stability. A 12-column grid is used with wide gutters to prevent information density from feeling overwhelming.

Spacing is based on an **8px linear scale**. All component dimensions, padding, and margins must be multiples of 8. This mathematical rigor ensures visual harmony and reinforces the "precision engineering" aspect of the brand. Vertical rhythm is prioritized, with large gaps (stack-lg) between distinct content sections to allow the Slate White surfaces to act as a visual palette cleanser.

## Elevation & Depth

To maintain a modern and high-trust feel, the design system avoids heavy, "muddy" shadows. Instead, it utilizes **tonal layers and low-contrast outlines**. 

Depth is communicated through subtle shifts in surface color:
1.  **Level 0 (Background):** Slate White (#F8FAFC).
2.  **Level 1 (Cards/Containers):** Pure White (#FFFFFF) with a 1px solid border in Slate (#E2E8F0).
3.  **Level 2 (Popovers/Modals):** Pure White with an extremely diffused, 10% opacity Deep Navy shadow (0px 10px 25px).

Interactive elements like buttons do not use shadows but instead use color transitions or a 1px "inner glow" border in Energy Green when focused or active.

## Shapes

The shape language is **Soft (0.25rem)**. This slight rounding takes the "edge" off the industrial aesthetic without making the UI feel overly consumer-grade or "playful." 

It strikes a balance between the sharp precision of solar hardware and the modern friendliness of a high-end service provider. All buttons, input fields, and cards should adhere to this 4px base radius. Large containers or decorative elements may use the `rounded-lg` (8px) variant to provide a softer frame for imagery or complex data visualizations.

## Components

### Buttons
Primary buttons use the Deep Navy background with a subtle vertical gradient and Slate White text. Secondary buttons are outlined in Deep Navy. The Energy Green is reserved for "Action-Complete" states or specific "Get Started" buttons to draw maximum attention.

### Input Fields
Fields use a Slate White background with a 1px border. On focus, the border transitions to Deep Navy with a 2px Energy Green "focus ring" indicator. Labels are always positioned above the field for maximum clarity.

### Cards
Cards are white with a subtle Slate border. They should be used to group related metrics (e.g., "Daily Yield," "System Health"). Use consistent internal padding of 24px (stack-md).

### Data Visualization
Charts should use Energy Green for "Generated Power" and Deep Navy for "Consumption." Use clean, sans-serif labels and avoid distracting grid lines; prefer a minimalist "ghost" grid.

### Icons
Icons must be thin-stroke (1.5pt or 2pt) and strictly geometric. Avoid filled icons unless used for active navigation states. The icon color should match the text color it accompanies to maintain a unified, high-contrast look.